namespace AnimalCentre.Models.Animals
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;
        private bool isAdpot;
        private bool isChipped;
        private bool isVaccinated;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.isAdpot = false;
            this.isChipped = false;
            this.isVaccinated = false;
        }

        public string Name { get; protected set; }

        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt
        {
            get => this.isAdpot;
            set
            {
                this.isAdpot = value;
            }
        }

        public bool IsChipped
        {
            get => this.isChipped;
            set
            {
                this.isChipped = value;
            }
        }

        public bool IsVaccinated
        {
            get => this.isVaccinated;
            set
            {
                this.isVaccinated = value;
            }
        }
    }
}
