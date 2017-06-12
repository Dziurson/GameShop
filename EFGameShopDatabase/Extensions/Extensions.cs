using EFGameShopDatabase.Enums;
using System;

namespace EFGameShopDatabase.Extensions
{
    public static class Extensions
    {
        public static string WithDate(this string value)
        {
            return DateTime.Now + " " + value;
        }

        public static string Map(this ItemType itemtype)
        {
            switch(itemtype)
            {
                case ItemType.Accessory:
                    return "accessory";
                case ItemType.Console:
                    return "console";
                case ItemType.GameBox:
                    return "game";
                case ItemType.GameDigital:
                    return "gamedigital";
                default:
                    return "";
            }
        }
    }
}
