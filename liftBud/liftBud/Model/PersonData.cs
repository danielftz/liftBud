using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
using Xamarin.Forms;

namespace liftBud.Model
{
    public class PersonData
    {
        [PrimaryKey]
        public DateTime CurrentDateTime { get; set; }

        public String Id { get; set; }

        public bool Male { get; set; } = true;

        public int Age { get; set; } = 0;

        public double Height { get; set; } = 0; //cm

        public double Weight { get; set; } = 0; //kg

        public double Waist_m { get; set; } = 0; //waist cm

        public double Neck_m { get; set; } = 0; //neck cm

        public double Hip_m { get; set; } = 0; //hip(female) cm

        double _BFPercent = 0;
        public double BFPercent //body fat percentage 
        {
            get
            {
                return this._BFPercent;
            }
            
            set// using US navy method
            {
                if (this.Male) //set male body fat percentage 
                {
                    if (this.Waist_m != 0 && this.Neck_m != 0 && this.Height != 0)
                    {
                        this._BFPercent = 495F / (1.0324 - 0.19077 * Math.Log10(this.Waist_m - this.Neck_m)
                            + 0.15456 * Math.Log10((double)this.Height)) - 450F;
                    }
                    else this._BFPercent = value;
                }
                else // set female body fat percentage 
                {
                    if (this.Waist_m != 0 && this.Neck_m != 0 
                        && this.Hip_m != 0 && this.Height != 0)
                    {
                        this._BFPercent = 495F / (1.29579 - 0.35004 * Math.Log10(this.Waist_m + this.Hip_m - this.Neck_m)
                            + 0.22100 * Math.Log10((double)this.Height)) - 450F;
                    }
                    else this._BFPercent = value;
                }
                
            }
        }

        double _LBM = 0;
        //must manually set
        public double LBM//Lean body mass
        {
            get
            {
                
                return this._LBM;
                
            }

            set {
                if (this._BFPercent != 0 && this.Weight != 0)
                {
                    this._LBM = (double)this.Weight * (1f - this._BFPercent / 100);
                }
            }
        }
        double _FFMI = 0; 
        public double FFMI//fat free mass index
        {
            get
            {
                return this._FFMI;
            }
            set {
                if (this._LBM != 0 && this.Height != 0)
                {
                    this._FFMI = this._LBM * Math.Pow(((double)this.Height / 100), -2f) + 6.1 * (1.8 - (double)this.Height / 100);

                }
            }

        }

        public bool NormalModel { get; set; } = true;

        double _activity_modifier = 0; //activity modifier
        public int Activity
        {
            get 
            {
                switch (this._activity_modifier)
                {
                    case 1.2:
                        return 0;
                    case 1.375:
                        return 1;
                    case 1.55:
                        return 2;
                    case 1.725:
                        return 3;
                    case 1.9:
                        return 4;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (value)
                {
                    case 0:
                        this._activity_modifier = 1.2;
                        break;
                    case 1:
                        this._activity_modifier = 1.375;
                        break;
                    case 2:
                        this._activity_modifier = 1.55;
                        break;
                    case 3:
                        this._activity_modifier = 1.725;
                        break;
                    case 4:
                        this._activity_modifier = 1.9;
                        break;
                    default:
                        this._activity_modifier = 1.2;
                        break;
                }
            }
        }

        int _BMR = 0;
        //must manually set
        public int BMR
        {
            get
            {
                
                return this._BMR;

            }
            set {
                if (this.Weight != 0 && this.Height != 0 && this.Age != 0 && this._LBM != 0)
                {
                    if (this.NormalModel && this.Male)//mifflin-st.jeor model 
                    {
                        this._BMR = (int)Math.Round(9.99 * this.Weight + 6.25 * this.Height - 4.92 * this.Age + 5);

                    }
                    else if (this.NormalModel && !this.Male)
                    {
                        this._BMR = (int)Math.Round(9.99 * this.Weight + 6.25 * this.Height - 4.92 * this.Age - 161);

                    }
                    else if (!this.NormalModel)
                    {
                        this._BMR = (int)Math.Round(370 + 21.6 + this._LBM);

                    }
                }
            }
        }

        int _TDEE=0;
        //must manually set
        public int TDEE //total daily energy expenditure
        {
            get
            {
                
                return this._TDEE;
            }
            set 
            {
                if (this._BMR != 0 && this._activity_modifier != 0)
                {
                    this._TDEE = (int)Math.Round(this._BMR * this._activity_modifier);
                }
            }
        }

         
        double _goal_modifier = 1.1;
        public int Goal
        {
            get
            {
                switch (this._goal_modifier)
                {
                    case 1.1:
                        return 0;
                    case 1:
                        return 1;
                    case 0.85:
                        return 2;
                    case 0.75:
                        return 3;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (value)
                {
                    case 0:
                        this._goal_modifier = 1.1;
                        break;
                    case 1:
                        this._goal_modifier = 1;
                        break;
                    case 2:
                        this._goal_modifier = 0.85;
                        break;
                    case 3:
                        this._goal_modifier = 0.75;
                        break;
                    default:
                        this._goal_modifier = 1.1;
                        break;
                }
            }
        }

        int _TDEEG = 0;
        //must manually set
        public int TDEEG //total daily energy expenditure based on goal
        {
            get
            {
                
                return this._TDEEG;

            }
            set 
            {
                if (this._TDEE != 0 && this._goal_modifier != 1.1)
                {
                    this._TDEEG = (int)Math.Round(this._TDEE * this._goal_modifier);
                }
            }
        }

        public int MealsPerDay { get; set; } = 3;

        private int fat_gkCal = 9;
        private int carb_gkCal = 4;
        private int protein_gkCal = 4;
        private double auto_protein_modifier = 1.6;

        int _fat_amount;
        int _carb_amount;
        int _protein_amount;

        public int Protein_amount
        {
            get
            {
                return this._protein_amount;
            }
            set
            {
                this._protein_amount = (int)Math.Round(this.Weight * this.auto_protein_modifier);
            }
        }
        public int Fat_amount
        {
            get
            {
                return this._fat_amount;
            }
            set
            {
                var protein_calories = (double)Math.Round(this.Weight * this.auto_protein_modifier * this.protein_gkCal);
                var fat_percentage = (1 - protein_calories / this._TDEEG) * 0.36;
                this._fat_amount = (int)Math.Round(fat_percentage * this._TDEEG / this.fat_gkCal);

            }
        }

        public int Carb_amount
        {
            get
            {
                return this._carb_amount;
            }
            set
            {
                var protein_calories = (double)Math.Round(this.Weight * this.auto_protein_modifier * this.protein_gkCal);
                var carb_percentage = (1 - protein_calories / this._TDEEG) * 0.64;
                this._carb_amount = (int)Math.Round(carb_percentage * this._TDEEG / this.carb_gkCal);
            }
        }





        

        
        
        
        

        
        
        

    }
}
