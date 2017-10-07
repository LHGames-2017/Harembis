﻿using System;
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
        
        static PlayerInfo currentEnemy;

        Brain(GameInfo gameInfo, StartingState state)
        {
            gameInfo_ = gameInfo;
            extendedInfo_= new ExtendedInfo(gameInfo_.Player, state);
            
        }

        public string getNextAction() {

            updateCurrentState();

            switch (currentState_)
            {
                case States.Fight:

                case States.GoHome:

                case States.Mine:

                case States.Purchase:

                case States.Run:

                case States.Scout:

                case States.Upgrade:

                    break;

            }

        }

        void updateCurrentState()
        {
            updatePlayerState();
            switch (currentState_)
            {
                case States.Fight:

                case States.GoHome:

                case States.Mine:
                    currentState_ = findNextStateMine();
                    break;

                case States.Purchase:

                case States.Run:

                case States.Scout:

                case States.Upgrade:

                    break;

            }

        }

        States findNextStateMine()
        {
            States nextState = States.Mine;

            if (capacityState == Grade.FULL|| capacityState ==Grade.HIGH)
            {
                nextState = States.GoHome;
            }

            return nextState;
        }

        States findNextStateGoHome()
        {
            States nextState=States.GoHome;

            if (isHome)
            {

            }

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
