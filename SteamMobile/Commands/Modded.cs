﻿using System.Linq;

namespace SteamMobile.Commands
{
    public class Modded : Command
    {
        public override string Type { get { return "modded"; } }

        public override string Format { get { return ""; } }

        public override void Handle(CommandTarget target, string[] parameters)
        {
            if (!target.IsRoom)
                return;

            var modded = target.Room.Modded;
            modded.Add(target.Room.RoomInfo.Admin);
            modded = modded.OrderBy(n => n).ToList();

            target.Send(string.Format("Mods for this room: {0}", string.Join(", ", modded)));
        }
    }
}
