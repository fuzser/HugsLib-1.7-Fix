using Mono.Cecil;
using Mono.Cecil.Cil;

if (args.Length != 3)
{
    Console.Error.WriteLine("Usage: HugsLibDllPatcher <input dll> <allowed mod title> <output dll>");
    return 2;
}

string inputPath = Path.GetFullPath(args[0]);
string allowedModTitle = args[1];
string outputPath = Path.GetFullPath(args[2]);

using AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(inputPath);
TypeDefinition controller = assembly.MainModule.Types.Single(type =>
    type.FullName == "HugsLib.HugsLibController");
MethodDefinition checkMethod = controller.Methods.Single(method =>
    method.Name == "CheckForIncludedHugsLibAssembly");

Instruction titleInstruction = checkMethod.Body.Instructions.Single(instruction =>
    instruction.OpCode == OpCodes.Ldstr && Equals(instruction.Operand, "HugsLib"));
titleInstruction.Operand = allowedModTitle;

Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
assembly.Write(outputPath);
Console.WriteLine($"Updated HugsLib self-check title to: {allowedModTitle}");
return 0;
