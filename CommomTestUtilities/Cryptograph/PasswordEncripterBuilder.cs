using MyRecipeBook.Application.Services.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommomTestUtilities.Cryptograph;

public class PasswordEncripterBuilder
{
    public static PasswordEncrypter Build() => new PasswordEncrypter("abc1234");
}
