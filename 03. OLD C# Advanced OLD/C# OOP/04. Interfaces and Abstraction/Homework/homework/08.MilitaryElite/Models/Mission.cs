using _08.MilitaryElite.Interfaces;
using System;

namespace _08.MilitaryElite.Models
{
    public class Mission : IMission
    {
        private MissionState state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get
            {
                return this.state.ToString();
            }

            private set
            {
                MissionState state;

                if (!Enum.TryParse<MissionState>(value, out state))
                {
                    throw new ArgumentException();
                }

                this.state = state;
            }
        }

        string IMission.Name => throw new NotImplementedException();

        string IMission.State => throw new NotImplementedException();

        public void CompleteMission()
        {
            this.state = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {State}";
        }
    }
}
