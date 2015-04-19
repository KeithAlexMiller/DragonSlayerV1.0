using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        static int dragonHP = 200;
        static int heroHP = 100;

        static int healHP = 0;

        static int damageFromSword = 0;
        static int damageFromMagic = 0;
        static int damageFromDragon = 0;

        static int attackSuccesValue = 0;

        static string weaponChoiceInput = String.Empty;

        static string yesNoInput = String.Empty;

        static bool heroAttacking = true;

        static bool dragonAttacking = false;

        static bool isHitSuccessful = false;

        static bool gameOn = false;

        static bool gameOver = false;

        static void Main(string[] args)
        {
            Introduction(true);
            Console.WriteLine("The time for fear has passed so change your pants and take action! Frantically, press any key you wish.");
            Console.ReadKey();
            gameOn = true;
            Console.Clear();

            //gameOn value determines if game will run
            while (gameOn == true)
            {
                //determines end game scenario (Play Again?)
                if (gameOver == false)
                {
                    if (heroAttacking == true)
                    {
                        HPDisplay(true);
                        ChooseAction();
                        {

                            if (IsValidInput(weaponChoiceInput) == true)
                            {
                                HPDisplay(true);
                                DamageCalc(weaponChoiceInput);
                                if (IsAttackSuccessful(weaponChoiceInput))
                                {
                                    HPCalc();
                                }
                            }
                        }
                    }
                    else if (dragonAttacking == true)
                    {
                        HPDisplay(true);
                        DamageCalc(weaponChoiceInput);
                        IsAttackSuccessful(weaponChoiceInput);
                        HPCalc();

                    }
                    damageFromSword = 0;
                    damageFromMagic = 0;
                    damageFromDragon = 0;
                    healHP = 0;
                    weaponChoiceInput = String.Empty;
                }
                if (gameOver == true)
                {
                    EndGame(gameOver);
                }
            }
        }

        public static bool Introduction(bool intro)
        {
            Console.WriteLine("                        Welcome to the Combat Simulator");
            Console.WriteLine();
            Console.WriteLine("          The most realistic Dragon Fighting Simulator you will ever play.");
            Console.WriteLine();
            Console.WriteLine("Let's begin: ");
            Console.WriteLine();
            Console.Write("Once upon a time a dragon tried to");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" murder ");
            Console.ResetColor();
            Console.Write("a guy. ");
            Console.WriteLine("Not just any guy either.");
            Console.WriteLine();
            Console.Write("This dude's name was ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'Brad the Mighty'");
            Console.WriteLine(".");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Hit enter to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Here's the deal: \n\nBrad will choose an action. \n\nYou can convince him to do things by pressing 1, 2, or 3. \n\nHe can either attack with a sharp pointy thing, a mystical ball of flaming gas  or he can heal himself to continue the fight and vanquish his foe. \n\nThen it's the dragaon's turn to attack. \n\nThis will go on until someone dies. Let's root for the hero!");
            Console.WriteLine();
            Console.WriteLine("Hit enter to continue...");
            Console.ReadKey();
            Console.Clear();
            return true;
        }

        public static void ChooseAction()
        {
            if (gameOver == false && weaponChoiceInput == String.Empty && heroAttacking == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Choose an Action: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPRESS 1:");
                Console.ResetColor();
                Console.WriteLine("To convince Brad to attack the dragon with the smelly Sword of Infinite Sorrow \n(also, the dragon's name is 'Gary').");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPRESS 2:");
                Console.ResetColor();
                Console.WriteLine("To trick Brad into using the dark arts and attcking with a strange and \nrelatively unexplained fireball.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPRESS 3:");
                Console.ResetColor();
                Console.WriteLine("To buy Brad a drink so that he can heal instead of fight... (how cowardly).");
                Console.Write("\n\nEnter 1, 2, or 3 now: ");
                weaponChoiceInput = Console.ReadLine();
                Console.Clear();

            }
        }

        public static bool HPDisplay(bool isDisplayed)
        {
            if (heroHP <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have been ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("brutally slain");
                Console.ResetColor();
                Console.WriteLine(". It's not pretty.");
                heroAttacking = false;
                gameOver = true;
                gameOn = false;
            }
            if (dragonHP <= 0)
            {
                Console.Clear();
                Console.Write("Congratulations! Brad has ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("slain the dragon");
                Console.ResetColor();
                Console.WriteLine("!");
                Console.Write("Unfortunately he is suddenly with an odd sense of disgust, foreboding and shame. This is one case where violence was not the answer.");
                dragonAttacking = false;
                gameOver = true;
                gameOn = false;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                                                          Brad's Hit Points: " + heroHP);
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                               Gary the Dragon's Hit Points: " + dragonHP);
                Console.ResetColor();
                Console.WriteLine();
            }
            return true;
        }

        public static bool IsValidInput(string input)
        {
            if (gameOver == false)
            {
                if (weaponChoiceInput.All(Char.IsDigit) && weaponChoiceInput != null && weaponChoiceInput != string.Empty)
                {
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter numbers or letters only. Please try again.");
                    weaponChoiceInput = String.Empty;
                    yesNoInput = string.Empty;
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    return false;
                }
            }
            if (gameOver == true)
            {
                if (@"Nn".Any(yesNoInput.Contains) && yesNoInput != null && yesNoInput != string.Empty)
                {
                    return true;
                }
                if (@"Yy".Any(yesNoInput.Contains) && yesNoInput != null && yesNoInput != string.Empty)
                {
                    gameOver = false;
                    gameOn = true;
                    return true;
                }
            }
            return false;
        }
        public static int DamageCalc(string weaponChoiceInput)
        {

            if (dragonAttacking == true)
            {
                Random rnd = new Random();
                damageFromDragon = rnd.Next(5, 16);

                return damageFromDragon;
            }

            if (weaponChoiceInput == "1")
            {
                Random rnd = new Random();
                damageFromSword = rnd.Next(20, 36);

                return damageFromSword;
            }

            //hero chooses to attack with magic damage and random damge is set
            if (weaponChoiceInput == "2")
            {
                Random rnd = new Random();
                damageFromMagic = rnd.Next(10, 16);

                Console.WriteLine("Brad hurls a ball of fire at the dragaon. I know it's weird because it's a dragon, but nobody likes to be uncomfortably hot.");
                Console.WriteLine();
                Console.Write("Brad does ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0} damage", damageFromMagic);
                Console.ResetColor();
                Console.WriteLine("!");
                Console.WriteLine();
                Console.WriteLine("Quickly! Hit enter to continue...");
                Console.ReadKey();

                return damageFromMagic;
            }
            //hero chooses to heal by drinking the 'Mead of Epic Inebriation' and random amount of HP is restored
            if (weaponChoiceInput == "3")
            {
                Random rnd = new Random();
                healHP = rnd.Next(10, 21);

                Console.WriteLine("In order to forget his many past trangressions, (and to try to recover from the very common 'fatigue of dragon slaying') Brad drinks deeply from his trusty flask filled with the 'Mead of Epic Inebriation'.");

                Console.WriteLine();

                Console.Write("Brad gains ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0} hit points", healHP);
                Console.ResetColor();
                Console.Write("!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Quickly! Hit enter to continue...");

                Console.ReadKey();

                return heroHP;

            }
            else if (gameOver != true)
            {
                Console.WriteLine();
                Console.Write("Brad uses his fist to punch the dragon. Now he is left with a ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("bloody stump");
                Console.ResetColor();
                Console.Write(". I   can't say I'm surprised...");
                Console.Write("Gary deals a massively destructive blow!");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.Write("\nNext time just enter a number, ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1, 2 or 3");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" will work just fine. Come on dude (or  lady), a man's life depends on this.");
                Console.ResetColor();
                Console.WriteLine("\n\nHit enter to continue...");
                Console.ReadKey();
                Console.ResetColor();
                dragonAttacking = true;
                heroAttacking = false;
                damageFromDragon = 101;
                Console.Clear();
            }
            return 42;
        }

        public static bool IsAttackSuccessful(string weaponChoiceInput)
        {
            if (weaponChoiceInput == "1" && heroAttacking == true)
            {
                Random rnd = new Random();
                attackSuccesValue = rnd.Next(1, 11);
                if (attackSuccesValue <= 7)
                {
                    Console.WriteLine();
                    Console.WriteLine("Brad attacks the behemoth dragon with the Sword of Infinite Sorrow and Other Stuff. Also it smells like butterscotch! Mmmmmmm.... butterscotch.");
                    Console.WriteLine();
                    Console.Write("Brad's");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" attack succeeds");
                    Console.ResetColor();
                    Console.Write("! Awwww yeah... Stop. DAMAGE TIME!");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Brad does ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} damage", damageFromSword);
                    Console.ResetColor();
                    Console.WriteLine("!");
                    Console.WriteLine();
                    Console.WriteLine("Hit enter to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return isHitSuccessful = true;
                }
                else if (attackSuccesValue >= 8)
                {
                    Console.Write("Brad unshealths his sword of legend and run to attack and looks really quite heroic, until he trips and falls and impales himself. The ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("attack FAILS ");
                    Console.ResetColor();
                    Console.WriteLine("and frankly, it's a little pathetic.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Hit enter to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    damageFromSword = 0;
                    dragonAttacking = true;
                    heroAttacking = false;
                    return isHitSuccessful = false;
                }
            }

            if (weaponChoiceInput == "2" && heroAttacking == true)
            {
                return isHitSuccessful = true;
            }

            if (weaponChoiceInput == "3" && heroAttacking == true)
            {
                return isHitSuccessful = true;
            }

            if (dragonAttacking == true)
            {
                Random rnd = new Random();
                attackSuccesValue = rnd.Next(1, 11);
                if (attackSuccesValue <= 8)
                {
                    Console.WriteLine("Gary is not pleased. He attmepts to destroy Brad with harsh words that would wound even the strongest mens' spirit.");
                    Console.WriteLine();
                    Console.Write("The ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("attack succeeds");
                    Console.ResetColor();
                    Console.Write(". He does ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} emotional damage ", damageFromDragon);
                    Console.ResetColor();
                    Console.Write("to Brad.");
                    Console.WriteLine();
                    Console.WriteLine("Hit enter to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return isHitSuccessful = true;
                }
                else if (attackSuccesValue >= 9)
                {
                    Console.WriteLine();
                    Console.Write("Gary turned his rage onto our hero. He scorches the ground with his blazing breath but ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FAILS spectacularly");
                    Console.ResetColor();
                    Console.WriteLine(" by missing Brad completely and only killing several hundred bystanders!");
                    Console.WriteLine();
                    Console.Write("He does ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("0 damage");
                    Console.ResetColor();
                    Console.WriteLine(" but that happens to the best of us.");
                    Console.WriteLine();
                    Console.WriteLine("Hit enter to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    damageFromDragon = 0;
                    return isHitSuccessful = false;
                }
            }

            attackSuccesValue = 0;
            return isHitSuccessful;
        }
        public static void HPCalc()
        {
            if (dragonHP != 0 && heroAttacking == true)
            {
                Console.Clear();
                dragonHP -= damageFromSword;
                dragonHP -= damageFromMagic;
                heroHP += healHP;
            }
            if (heroHP != 0 && dragonAttacking == true)
            {
                Console.Clear();
                heroHP -= damageFromDragon;
            }
            if (dragonAttacking == true)
            {
                dragonAttacking = false;
                heroAttacking = true;

            }
            else if (heroAttacking == true)
            {
                heroAttacking = false;
                dragonAttacking = true;
            }
        }

        public static bool EndGame(bool gameOver)
        {
            {
                dragonAttacking = false;
                heroAttacking = false;
                Console.WriteLine();
                Console.WriteLine("The game is OVER, but don't cry about it or anything. You can play again!");
                Console.WriteLine();
                Console.Write("How about it fella? YES/NO ");
                yesNoInput = Console.ReadLine();
            }

            if (IsValidInput(yesNoInput) && @"Yy".Any(yesNoInput.Contains))
            {
                Console.WriteLine();
                Console.WriteLine("The dragon has arisen. Let's play again!");
                gameOn = true;
                gameOver = false;
                dragonHP = 200;
                heroHP = 100;
                heroAttacking = true;
                dragonAttacking = false;
                damageFromSword = 0;
                damageFromMagic = 0;
                damageFromDragon = 0;
                healHP = 0;
                Console.ReadKey();
                return true;
            }
            if (IsValidInput(yesNoInput) && @"Nn".Any(yesNoInput.Contains))
            {
                Console.WriteLine();
                Console.WriteLine("You are a weak and feeble player...");
                gameOn = false;
                gameOver = true;
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
