using System;
using System.IO;
using System.Linq;
using Neo;
using Neo.VM;
using Neo.Cryptography;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new ExecutionEngine(null, Crypto.Default);
            engine.LoadScript(File.ReadAllBytes(@"../../net-core-test/net-core-test/bin/Debug/netstandard2.0/net-core-test.avm")); 

            using (ScriptBuilder sb = new ScriptBuilder())
            {
                sb.EmitPush(2); // 对应形参 c
                sb.EmitPush(4); // 对应形参 b
                sb.EmitPush(3); // 对应形参 a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // 开始执行

            var result = engine.EvaluationStack.Peek().GetBigInteger(); // 在这里设置返回值
            Console.WriteLine($"执行结果 {result}");
            Console.ReadLine();
        }
    }
}