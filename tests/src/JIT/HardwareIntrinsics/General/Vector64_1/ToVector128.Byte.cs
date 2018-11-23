// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\General\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace JIT.HardwareIntrinsics.General
{
    public static partial class Program
    {
        private static void ToVector128Byte()
        {
            var test = new VectorExtend__ToVector128Byte();

            // Validates basic functionality works
            test.RunBasicScenario();

            // Validates calling via reflection works
            test.RunReflectionScenario();

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class VectorExtend__ToVector128Byte
    {
        private static readonly int LargestVectorSize = 8;

        private static readonly int ElementCount = Unsafe.SizeOf<Vector64<Byte>>() / sizeof(Byte);

        public bool Succeeded { get; set; } = true;

        public void RunBasicScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario));

            Byte[] values = new Byte[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                values[i] = TestLibrary.Generator.GetByte();
            }

            Vector64<Byte> value = Vector64.Create(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);

            Vector128<Byte> result = value.ToVector128();
            ValidateResult(result, values, isUnsafe: false);

            Vector128<Byte> unsafeResult = value.ToVector128Unsafe();
            ValidateResult(unsafeResult, values, isUnsafe: true);
        }

        public void RunReflectionScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario));

            Byte[] values = new Byte[ElementCount];

            for (int i = 0; i < ElementCount; i++)
            {
                values[i] = TestLibrary.Generator.GetByte();
            }

            Vector64<Byte> value = Vector64.Create(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);

            object result = typeof(Vector64<Byte>)
                                .GetMethod(nameof(Vector64<Byte>.ToVector128), new Type[] { })
                                .Invoke(value, new object[] { });
            ValidateResult((Vector128<Byte>)(result), values, isUnsafe: false);

            object unsafeResult = typeof(Vector64<Byte>)
                                    .GetMethod(nameof(Vector64<Byte>.ToVector128), new Type[] { })
                                    .Invoke(value, new object[] { });
            ValidateResult((Vector128<Byte>)(unsafeResult), values, isUnsafe: true);
        }

        private void ValidateResult(Vector128<Byte> result, Byte[] values, bool isUnsafe, [CallerMemberName] string method = "")
        {
            Byte[] resultElements = new Byte[ElementCount * 2];
            Unsafe.WriteUnaligned(ref Unsafe.As<Byte, byte>(ref resultElements[0]), result);

            ValidateResult(resultElements, values, isUnsafe, method);
        }

        private void ValidateResult(Byte[] result, Byte[] values, bool isUnsafe, [CallerMemberName] string method = "")
        {
            bool succeeded = true;

            for (int i = 0; i < ElementCount; i++)
            {
                if (result[i] != values[i])
                {
                    succeeded = false;
                    break;
                }
            }

            if (!isUnsafe)
            {
                for (int i = ElementCount; i < ElementCount * 2; i++)
                {
                    if (result[i] != 0)
                    {
                        succeeded = false;
                        break;
                    }
                }
            }

            if (!succeeded)
            {
                TestLibrary.TestFramework.LogInformation($"Vector64<Byte>.ToVector128{(isUnsafe ? "Unsafe" : "")}(): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"   value: ({string.Join(", ", values)})");
                TestLibrary.TestFramework.LogInformation($"  result: ({string.Join(", ", result)})");
                TestLibrary.TestFramework.LogInformation(string.Empty);

                Succeeded = false;
            }
        }
    }
}
