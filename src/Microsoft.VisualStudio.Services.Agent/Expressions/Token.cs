﻿namespace Microsoft.VisualStudio.Services.Agent.Expressions
{
    // todo: make internal
    public sealed class Token
    {
        public Token(TokenKind kind, int index, int length = 1, object parsedValue = null)
        {
            Kind = kind;
            Index = index;
            Length = length;
            ParsedValue = parsedValue;
        }

        public TokenKind Kind { get; }

        public int Index { get; }

        public int Length { get; }

        public object ParsedValue { get; }
    }

    // todo: make internal
    public enum TokenKind
    {
        // Punctuation
        StartIndex,
        StartParameter,
        EndIndex,
        EndParameter,
        Separator,
        Dereference,

        // Literal value types
        Boolean,
        Number,
        Version,
        String,

        // Functions
        And,
        Equal,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Not,
        NotEqual,
        Or,
        Xor,

        // Extensions
        ExtensionObject,

        Unrecognized,
    }
}
