﻿

namespace Shared;

public class Utils
{
    public static string? ParsEmailDomain(string email)
    {
        var splitted = email.Split('@');
        if (splitted.Length != 2)
            return null;

        return splitted[1].ToLower();
    }
}
