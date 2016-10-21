﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Dynamic.Utils;
using System.Reflection;

namespace System.Linq.Expressions.Interpreter
{
    internal abstract class RightShiftInstruction : Instruction
    {
        private static Instruction s_SByte, s_int16, s_int32, s_int64, s_byte, s_UInt16, s_UInt32, s_UInt64;

        public override int ConsumedStack => 2;
        public override int ProducedStack => 1;
        public override string InstructionName => "RightShift";

        private RightShiftInstruction() { }

        internal sealed class RightShiftSByte : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push((SByte)(((SByte)value) >> ((int)shift)));
                }
                return +1;
            }
        }

        internal sealed class RightShiftInt16 : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push((Int16)(((Int16)value) >> ((int)shift)));
                }
                return +1;
            }
        }

        internal sealed class RightShiftInt32 : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push(((Int32)value) >> ((int)shift));
                }
                return +1;
            }
        }

        internal sealed class RightShiftInt64 : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push(((Int64)value) >> ((int)shift));
                }
                return +1;
            }
        }

        internal sealed class RightShiftByte : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push((Byte)(((Byte)value) >> ((int)shift)));
                }
                return +1;
            }
        }

        internal sealed class RightShiftUInt16 : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push((UInt16)(((UInt16)value) >> ((int)shift)));
                }
                return +1;
            }
        }

        internal sealed class RightShiftUInt32 : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push(((UInt32)value) >> ((int)shift));
                }
                return +1;
            }
        }

        internal sealed class RightShiftUInt64 : RightShiftInstruction
        {
            public override int Run(InterpretedFrame frame)
            {
                object shift = frame.Pop();
                object value = frame.Pop();
                if (value == null || shift == null)
                {
                    frame.Push(null);
                }
                else
                {
                    frame.Push(((UInt64)value) >> ((int)shift));
                }
                return +1;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static Instruction Create(Type type)
        {
            // Boxed enums can be unboxed as their underlying types:
            Type underlyingType = type.GetTypeInfo().IsEnum ? Enum.GetUnderlyingType(type) : TypeUtils.GetNonNullableType(type);

            switch (underlyingType.GetTypeCode())
            {
                case TypeCode.SByte: return s_SByte ?? (s_SByte = new RightShiftSByte());
                case TypeCode.Byte: return s_byte ?? (s_byte = new RightShiftByte());
                case TypeCode.Int16: return s_int16 ?? (s_int16 = new RightShiftInt16());
                case TypeCode.Int32: return s_int32 ?? (s_int32 = new RightShiftInt32());
                case TypeCode.Int64: return s_int64 ?? (s_int64 = new RightShiftInt64());

                case TypeCode.UInt16: return s_UInt16 ?? (s_UInt16 = new RightShiftUInt16());
                case TypeCode.UInt32: return s_UInt32 ?? (s_UInt32 = new RightShiftUInt32());
                case TypeCode.UInt64: return s_UInt64 ?? (s_UInt64 = new RightShiftUInt64());

                default:
                    throw Error.ExpressionNotSupportedForType("RightShift", type);
            }
        }
    }
}