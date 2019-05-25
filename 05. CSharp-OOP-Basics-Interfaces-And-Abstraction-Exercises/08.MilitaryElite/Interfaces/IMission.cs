using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Interfaces
{
    public interface IMission
    {
        string MissionName { get; }
        string State { get; }

        void CompleteMission();
    }
}
