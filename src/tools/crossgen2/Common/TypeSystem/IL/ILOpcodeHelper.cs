// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Debug = System.Diagnostics.Debug;

namespace Internal.IL
{
    public static class ILOpcodeHelper
    {
        private const byte VariableSize = 0xFF;
        private const byte Invalid = 0xFE;

        /// <summary>
        /// Gets the size, in bytes, of the opcode and its arguments.
        /// Note: if '<paramref name="opcode"/>' is <see cref="ILOpcode.switch_"/>,
        /// the caller must handle it differently as that opcode is variable sized.
        /// </summary>
        public static int GetSize(this ILOpcode opcode)
        {
            Debug.Assert((uint)opcode < (uint)s_opcodeSizes.Length);
            byte result = s_opcodeSizes[(int)opcode];
            Debug.Assert(result != VariableSize);
            Debug.Assert(result != Invalid);
            return result;
        }

        /// <summary>
        /// Returns true if '<paramref name="opcode"/>' is a valid opcode.
        /// </summary>
        public static bool IsValid(this ILOpcode opcode)
        {
            return (uint)opcode < (uint)s_opcodeSizes.Length
                && s_opcodeSizes[(int)opcode] != Invalid;
        }

        private static readonly byte[] s_opcodeSizes = new byte[]
        {
            1, // nop = 0x00,
            1, // break_ = 0x01,
            1, // ldarg_0 = 0x02,
            1, // ldarg_1 = 0x03,
            1, // ldarg_2 = 0x04,
            1, // ldarg_3 = 0x05,
            1, // ldloc_0 = 0x06,
            1, // ldloc_1 = 0x07,
            1, // ldloc_2 = 0x08,
            1, // ldloc_3 = 0x09,
            1, // stloc_0 = 0x0a,
            1, // stloc_1 = 0x0b,
            1, // stloc_2 = 0x0c,
            1, // stloc_3 = 0x0d,
            2, // ldarg_s = 0x0e,
            2, // ldarga_s = 0x0f,
            2, // starg_s = 0x10,
            2, // ldloc_s = 0x11,
            2, // ldloca_s = 0x12,
            2, // stloc_s = 0x13,
            1, // ldnull = 0x14,
            1, // ldc_i4_m1 = 0x15,
            1, // ldc_i4_0 = 0x16,
            1, // ldc_i4_1 = 0x17,
            1, // ldc_i4_2 = 0x18,
            1, // ldc_i4_3 = 0x19,
            1, // ldc_i4_4 = 0x1a,
            1, // ldc_i4_5 = 0x1b,
            1, // ldc_i4_6 = 0x1c,
            1, // ldc_i4_7 = 0x1d,
            1, // ldc_i4_8 = 0x1e,
            2, // ldc_i4_s = 0x1f,
            5, // ldc_i4 = 0x20,
            9, // ldc_i8 = 0x21,
            5, // ldc_r4 = 0x22,
            9, // ldc_r8 = 0x23,
            Invalid, // = 0x24,
            1, // dup = 0x25,
            1, // pop = 0x26,
            5, // jmp = 0x27,
            5, // call = 0x28,
            5, // calli = 0x29,
            1, // ret = 0x2a,
            2, // br_s = 0x2b,
            2, // brfalse_s = 0x2c,
            2, // brtrue_s = 0x2d,
            2, // beq_s = 0x2e,
            2, // bge_s = 0x2f,
            2, // bgt_s = 0x30,
            2, // ble_s = 0x31,
            2, // blt_s = 0x32,
            2, // bne_un_s = 0x33,
            2, // bge_un_s = 0x34,
            2, // bgt_un_s = 0x35,
            2, // ble_un_s = 0x36,
            2, // blt_un_s = 0x37,
            5, // br = 0x38,
            5, // brfalse = 0x39,
            5, // brtrue = 0x3a,
            5, // beq = 0x3b,
            5, // bge = 0x3c,
            5, // bgt = 0x3d,
            5, // ble = 0x3e,
            5, // blt = 0x3f,
            5, // bne_un = 0x40,
            5, // bge_un = 0x41,
            5, // bgt_un = 0x42,
            5, // ble_un = 0x43,
            5, // blt_un = 0x44,
            VariableSize, //  switch_ = 0x45,
            1, // ldind_i1 = 0x46,
            1, // ldind_u1 = 0x47,
            1, // ldind_i2 = 0x48,
            1, // ldind_u2 = 0x49,
            1, // ldind_i4 = 0x4a,
            1, // ldind_u4 = 0x4b,
            1, // ldind_i8 = 0x4c,
            1, // ldind_i = 0x4d,
            1, // ldind_r4 = 0x4e,
            1, // ldind_r8 = 0x4f,
            1, // ldind_ref = 0x50,
            1, // stind_ref = 0x51,
            1, // stind_i1 = 0x52,
            1, // stind_i2 = 0x53,
            1, // stind_i4 = 0x54,
            1, // stind_i8 = 0x55,
            1, // stind_r4 = 0x56,
            1, // stind_r8 = 0x57,
            1, // add = 0x58,
            1, // sub = 0x59,
            1, // mul = 0x5a,
            1, // div = 0x5b,
            1, // div_un = 0x5c,
            1, // rem = 0x5d,
            1, // rem_un = 0x5e,
            1, // and = 0x5f,
            1, // or = 0x60,
            1, // xor = 0x61,
            1, // shl = 0x62,
            1, // shr = 0x63,
            1, // shr_un = 0x64,
            1, // neg = 0x65,
            1, // not = 0x66,
            1, // conv_i1 = 0x67,
            1, // conv_i2 = 0x68,
            1, // conv_i4 = 0x69,
            1, // conv_i8 = 0x6a,
            1, // conv_r4 = 0x6b,
            1, // conv_r8 = 0x6c,
            1, // conv_u4 = 0x6d,
            1, // conv_u8 = 0x6e,
            5, // callvirt = 0x6f,
            5, // cpobj = 0x70,
            5, // ldobj = 0x71,
            5, // ldstr = 0x72,
            5, // newobj = 0x73,
            5, // castclass = 0x74,
            5, // isinst = 0x75,
            1, // conv_r_un = 0x76,
            Invalid, // = 0x77,
            Invalid, // = 0x78,
            5, // unbox = 0x79,
            1, // throw_ = 0x7a,
            5, // ldfld = 0x7b,
            5, // ldflda = 0x7c,
            5, // stfld = 0x7d,
            5, // ldsfld = 0x7e,
            5, // ldsflda = 0x7f,
            5, // stsfld = 0x80,
            5, // stobj = 0x81,
            1, // conv_ovf_i1_un = 0x82,
            1, // conv_ovf_i2_un = 0x83,
            1, // conv_ovf_i4_un = 0x84,
            1, // conv_ovf_i8_un = 0x85,
            1, // conv_ovf_u1_un = 0x86,
            1, // conv_ovf_u2_un = 0x87,
            1, // conv_ovf_u4_un = 0x88,
            1, // conv_ovf_u8_un = 0x89,
            1, // conv_ovf_i_un = 0x8a,
            1, // conv_ovf_u_un = 0x8b,
            5, // box = 0x8c,
            5, // newarr = 0x8d,
            1, // ldlen = 0x8e,
            5, // ldelema = 0x8f,
            1, // ldelem_i1 = 0x90,
            1, // ldelem_u1 = 0x91,
            1, // ldelem_i2 = 0x92,
            1, // ldelem_u2 = 0x93,
            1, // ldelem_i4 = 0x94,
            1, // ldelem_u4 = 0x95,
            1, // ldelem_i8 = 0x96,
            1, // ldelem_i = 0x97,
            1, // ldelem_r4 = 0x98,
            1, // ldelem_r8 = 0x99,
            1, // ldelem_ref = 0x9a,
            1, // stelem_i = 0x9b,
            1, // stelem_i1 = 0x9c,
            1, // stelem_i2 = 0x9d,
            1, // stelem_i4 = 0x9e,
            1, // stelem_i8 = 0x9f,
            1, // stelem_r4 = 0xa0,
            1, // stelem_r8 = 0xa1,
            1, // stelem_ref = 0xa2,
            5, // ldelem = 0xa3,
            5, // stelem = 0xa4,
            5, // unbox_any = 0xa5,
            Invalid, // = 0xa6,
            Invalid, // = 0xa7,
            Invalid, // = 0xa8,
            Invalid, // = 0xa9,
            Invalid, // = 0xaa,
            Invalid, // = 0xab,
            Invalid, // = 0xac,
            Invalid, // = 0xad,
            Invalid, // = 0xae,
            Invalid, // = 0xaf,
            Invalid, // = 0xb0,
            Invalid, // = 0xb1,
            Invalid, // = 0xb2,
            1, // conv_ovf_i1 = 0xb3,
            1, // conv_ovf_u1 = 0xb4,
            1, // conv_ovf_i2 = 0xb5,
            1, // conv_ovf_u2 = 0xb6,
            1, // conv_ovf_i4 = 0xb7,
            1, // conv_ovf_u4 = 0xb8,
            1, // conv_ovf_i8 = 0xb9,
            1, // conv_ovf_u8 = 0xba,
            Invalid, // = 0xbb,
            Invalid, // = 0xbc,
            Invalid, // = 0xbd,
            Invalid, // = 0xbe,
            Invalid, // = 0xbf,
            Invalid, // = 0xc0,
            Invalid, // = 0xc1,
            5, // refanyval = 0xc2,
            1, // ckfinite = 0xc3,
            Invalid, // = 0xc4,
            Invalid, // = 0xc5,
            5, // mkrefany = 0xc6,
            Invalid, // = 0xc7,
            Invalid, // = 0xc8,
            Invalid, // = 0xc9,
            Invalid, // = 0xca,
            Invalid, // = 0xcb,
            Invalid, // = 0xcc,
            Invalid, // = 0xcd,
            Invalid, // = 0xce,
            Invalid, // = 0xcf,
            5, // ldtoken = 0xd0,
            1, // conv_u2 = 0xd1,
            1, // conv_u1 = 0xd2,
            1, // conv_i = 0xd3,
            1, // conv_ovf_i = 0xd4,
            1, // conv_ovf_u = 0xd5,
            1, // add_ovf = 0xd6,
            1, // add_ovf_un = 0xd7,
            1, // mul_ovf = 0xd8,
            1, // mul_ovf_un = 0xd9,
            1, // sub_ovf = 0xda,
            1, // sub_ovf_un = 0xdb,
            1, // endfinally = 0xdc,
            5, // leave = 0xdd,
            2, // leave_s = 0xde,
            1, // stind_i = 0xdf,
            1, // conv_u = 0xe0,
            Invalid, // = 0xe1,
            Invalid, // = 0xe2,
            Invalid, // = 0xe3,
            Invalid, // = 0xe4,
            Invalid, // = 0xe5,
            Invalid, // = 0xe6,
            Invalid, // = 0xe7,
            Invalid, // = 0xe8,
            Invalid, // = 0xe9,
            Invalid, // = 0xea,
            Invalid, // = 0xeb,
            Invalid, // = 0xec,
            Invalid, // = 0xed,
            Invalid, // = 0xee,
            Invalid, // = 0xef,
            Invalid, // = 0xf0,
            Invalid, // = 0xf1,
            Invalid, // = 0xf2,
            Invalid, // = 0xf3,
            Invalid, // = 0xf4,
            Invalid, // = 0xf5,
            Invalid, // = 0xf6,
            Invalid, // = 0xf7,
            Invalid, // = 0xf8,
            Invalid, // = 0xf9,
            Invalid, // = 0xfa,
            Invalid, // = 0xfb,
            Invalid, // = 0xfc,
            Invalid, // = 0xfd,
            1, // prefix1 = 0xfe,
            Invalid, // = 0xff,
            2, // arglist = 0x100,
            2, // ceq = 0x101,
            2, // cgt = 0x102,
            2, // cgt_un = 0x103,
            2, // clt = 0x104,
            2, // clt_un = 0x105,
            6, // ldftn = 0x106,
            6, // ldvirtftn = 0x107,
            Invalid, // = 0x108,
            4, // ldarg = 0x109,
            4, // ldarga = 0x10a,
            4, // starg = 0x10b,
            4, // ldloc = 0x10c,
            4, // ldloca = 0x10d,
            4, // stloc = 0x10e,
            2, // localloc = 0x10f,
            Invalid, // = 0x110,
            2, // endfilter = 0x111,
            3, // unaligned = 0x112,
            2, // volatile_ = 0x113,
            2, // tail = 0x114,
            6, // initobj = 0x115,
            6, // constrained = 0x116,
            2, // cpblk = 0x117,
            2, // initblk = 0x118,
            3, // no = 0x119,
            2, // rethrow = 0x11a,
            Invalid, // = 0x11b,
            6, // sizeof_ = 0x11c,
            2, // refanytype = 0x11d,
            2, // readonly_ = 0x11e,
        };
    }
}
