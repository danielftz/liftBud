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

        public int Id { get; set; } = -1;

        public bool Male { get; set; } = true;

        public int Age { get; set; } = -1;

        public int Height { get; set; } = -1; //cm

        public int Weight { get; set; } = -1; //kg

        public double Measurement1 { get; set; } = -1; //waist cm

        public double Measurement2 { get; set; } = -1; //neck cm

        public double Measurement3 { get; set; } = -1; //hip(female) cm

        double _BFPercent = -1f;
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
                    if (this.Measurement1 != -1 && this.Measurement2 != -1 && this.Height != -1)
                    {
                        this._BFPercent = 495F / (1.0324 - 0.19077 * Math.Log10(this.Measurement1 - this.Measurement2)
                            + 0.15456 * Math.Log10((double)this.Height)) - 450F;
                    }
                    else this._BFPercent = value;
                }
                else // set female body fat percentage 
                {
                    if (this.Measurement1 != -1 && this.Measurement2 != -1 
                        && this.Measurement3 != -1 && this.Height != -1)
                    {
                        this._BFPercent = 495F / (1.29579 - 0.35004 * Math.Log10(this.Measurement1 + this.Measurement3 - this.Measurement2)
                            + 0.22100 * Math.Log10((double)this.Height)) - 450F;
                    }
                    else this._BFPercent = value;
                }
                
            }
        }

        double _LBM = -1f;
        //must manually set
        public double LBM//Lean body mass
        {
            get
            {
                
                return this._LBM;
                
            }

            set {
                if (this._BFPercent != -1 && this.Weight != -1)
                {
                    this._LBM = (double)this.Weight * (1f - this._BFPercent / 100);
                }
            }
        }
        double _FFMI = -1f; 
        public double FFMI//fat free mass index
        {
            get
            {
                return this._FFMI;
            }
            set {
                if (this._LBM != -1 && this.Height != -1)
                {
                    this._FFMI = this._LBM * Math.Pow(((double)this.Height / 100), -2f) + 6.1 * (1.8 - (double)this.Height / 100);

                }
            }

        }

        public bool NormalModel { get; set; } = true;

        double _activity_modifier = -1; //activity modifier
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
                        return -1;
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
                        this._activity_modifier = -1;
                        break;
                }
            }
        }

        int _BMR = -1;
        //must manually set
        public int BMR
        {
            get
            {
                
                return this._BMR;

            }
            set {
                if (this.Weight != -1 && this.Height != -1 && this.Age != -1 && this._LBM != -1)
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

        int _TDEE=-1;
        //must manually set
        public int TDEE //total daily energy expenditure
        {
            get
            {
                
                return this._TDEE;
            }
            set 
            {
                if (this._BMR != -1 && this._activity_modifier != -1)
                {
                    this._TDEE = (int)Math.Round(this._BMR * this._activity_modifier);
                }
            }
        }

         
        double _goal_modifier = -1;
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
                    case 0.95:
                        return 2;
                    case 0.9:
                        return 3;
                    case 0.85:
                        return 4;
                    case 0.8:
                        return 5;
                    case 0.75:
                        return 6;
                    default:
                        return -1;
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
                        this._goal_modifier = 0.95;
                        break;
                    case 3:
                        this._goal_modifier = 0.9;
                        break;
                    case 4:
                        this._goal_modifier = 0.85;
                        break;
                    case 5:
                        this._goal_modifier = 0.8;
                        break;
                    case 6:
                        this._goal_modifier = 0.75;
                        break;
                    default:
                        this._goal_modifier = -1;
                        break;
                }
            }
        }

        int _TDEEG = -1;
        //must manually set
        public int TDEEG //total daily energy expenditure based on goal
        {
            get
            {
                
                return this._TDEEG;

            }
            set 
            {
                if (this._TDEE != -1 && this._goal_modifier != -1)
                {
                    this._TDEEG = (int)Math.Round(this._TDEE * this._goal_modifier);
                }
            }
        }

        public int MealsPerDay { get; set; } = -1;

        private int fat_gkCal = 9;
        private int carb_gkCal = 4;
        private int protein_gkCal = 4;



        

        
        
        
        

        
        
        

    }
}
