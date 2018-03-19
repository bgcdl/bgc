using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Sum : SmartContract
{
    public static int Main(int a, int b, int c)
    {
        return a + b;
    }
}