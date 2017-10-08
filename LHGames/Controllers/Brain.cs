using System;
using System.Collections.Generic;
using System.Text;
using StarterProject.Web.Api;


namespace Harembis
{
    class Brain
    {
        static ExtendedInfo extendedInfo_;
        static UpgradeSkill skillUpgrade_;
        static UpgradeItem itemPurchase_;
        static GameInfo gameInfo_;

        static States currentState_;

        static Grade HPState, capacityState;
        
        //static PlayerInfo currentEnemy;

        static MapManager mapManager;

        static bool isUpgraded;

        static bool isBought;

       public Brain(GameInfo gameInfo, StartingState state, Tile [,] map)
        {
            gameInfo_ = gameInfo;
            extendedInfo_= new ExtendedInfo(gameInfo_.Player, state);
            mapManager = new MapManager(gameInfo, map);
            skillUpgrade_ = new UpgradeSkill(gameInfo_.Player, extendedInfo_);
            itemPurchase_ = new UpgradeItem(gameInfo_.Player, extendedInfo_);
            currentState_ = States.Mine;
            HPState = Grade.FULL;
            
        }

        public string getNextAction() {

            updateCurrentState();

            switch (currentState_)
            {
                //case States.Fight:
                  //  return getNextActionFight();

                //case States.GoHome:
                    
                    
                case States.Mine:
                    return mapManager.mine();

              //  case States.Purchase:

                //case States.Run:

               // case States.Scout:

                case States.Upgrade:
                    return getNextActionUpgrade();
                default:
                    return mapManager.mine();

            }

        }

        //string getNextActionFight(){
        //    if (mapManager.isAdjacent(currentEnemy.Position))
        //        return AIHelper.CreateAttackAction(currentEnemy.Position);
        //    else
        //        return mapManager.getCloser(currentEnemy.Position);
        //}

        string getNextActionUpgrade(){
            if (mapManager.isHome())
            {
                isUpgraded = true;
                UpgradeType type = skillUpgrade_.getNextSkill().Item1;
                extendedInfo_.upgradeStat(type);
                return AIHelper.CreateUpgradeAction(type);
            }
            else
                return mapManager.getCloser(gameInfo_.Player.HouseLocation);
        }



        void updateCurrentState()
        {
            updatePlayerState();
            switch (currentState_)
            {
                case States.Fight:

                case States.GoHome:
                    currentState_ = findNextStateGoHome();
                    break;

                case States.Mine:
                    currentState_ = findNextStateMine();
                    break;

                case States.Purchase:
                    currentState_ = findNextStateUpgrade();
                    break;
                case States.Run:
                    currentState_ = findNextStateRun();
                    break;
                case States.Scout:

                case States.Upgrade:

                    break;

            }

        }


        States findNextStateUpgrade()
        {
            States nextState= States.Upgrade;
            if(isUpgraded)
            {
                nextState = States.Mine;
            }

            return nextState;
        } 

        States findNextStateRun()
        {
            States nextState = States.Run;

            

            return nextState;
        }

        States findNextStateMine()
        {
            States nextState = States.Mine;

            if (capacityState == Grade.FULL)
            {
                    nextState = States.Upgrade;
                    isUpgraded = false;
                }
            

            return nextState;
        }

        States findNextStateGoHome()
        {
            States nextState=States.GoHome;

       
 
            return nextState;
        }

        

        void updatePlayerState()
        {
            updateHPState();
            updateCapacityState();

        }

        void updateHPState()
        {
            if (gameInfo_.Player.Health == gameInfo_.Player.MaxHealth)
            {
                HPState = Grade.FULL;
            }
            else if(gameInfo_.Player.Health/ gameInfo_.Player.MaxHealth > 75)
            {
                HPState = Grade.HIGH;
            }
            else if (gameInfo_.Player.Health / gameInfo_.Player.MaxHealth > 50)
            {
                HPState = Grade.MEDIUM;
            }
            else if (gameInfo_.Player.Health / gameInfo_.Player.MaxHealth > 25)
            {
                HPState = Grade.LOW;
            }
            else
            {
                HPState = Grade.VERYLOW;
            }
        }

        Tuple<bool, States> Purchase()
        {
            Tuple<bool, States> answer = new Tuple<bool, States>(false,States.Scout);
            float homeDistance = mapManager.getDistance(gameInfo_.Player.HouseLocation);
                //shopDistance=mapManager.getDistance(mapManager.closestShop());
            bool affordUpgrade = skillUpgrade_.getNextSkill().Item2 < extendedInfo_.getTotalRessource();
               



            if (skillUpgrade_.getNextSkill().Item3 >= itemPurchase_.getNextItem().Item3) {
                if(gameInfo_.Player.CarriedResources > skillUpgrade_.getNextSkill().Item2)
                {
                    answer = new Tuple<bool, States>(true, States.Purchase);
                }
              
            }else
            {

            }

            return answer;
        }

        void updateCapacityState() {

            if (gameInfo_.Player.CarriedResources == gameInfo_.Player.CarryingCapacity)
            {
                capacityState = Grade.FULL;
            }
            else if (gameInfo_.Player.CarriedResources / gameInfo_.Player.CarryingCapacity > 75)
            {
                capacityState = Grade.HIGH;
            }
            else if (gameInfo_.Player.CarriedResources / gameInfo_.Player.CarryingCapacity> 50)
            {
                capacityState = Grade.MEDIUM;
            }
            else if (gameInfo_.Player.CarriedResources / gameInfo_.Player.CarryingCapacity> 25)
            {
                capacityState = Grade.LOW;
            }
            else
            {
                capacityState = Grade.VERYLOW;
            }
        }

    }
}
