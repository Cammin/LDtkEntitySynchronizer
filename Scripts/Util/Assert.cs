using System;

namespace LDtkDefinitionSync
{
    public static class Assert
    {
        public static void IsTrue(bool condition)
        {
            if (!condition) throw new Exception("Assertion failed");
        }
    }
}