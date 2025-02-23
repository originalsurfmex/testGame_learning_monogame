﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Minor Code Smell", "S1185:Overriding members should do more than simply call the same member in the base class", Justification = "<Pending>", Scope = "member", Target = "~M:testGame.Painter.Initialize")]
[assembly: SuppressMessage("Major Code Smell", "S3010:Static fields should not be updated in constructors", Justification = "<Pending>", Scope = "member", Target = "~M:testGame.Painter.#ctor")]
[assembly: SuppressMessage("Critical Code Smell", "S2696:Instance members should not write to \"static\" fields", Justification = "<Pending>", Scope = "member", Target = "~M:testGame.Painter.LoadContent")]
