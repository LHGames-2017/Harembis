using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Harembis;

namespace StarterProject.Web.Api.Controllers
{
    [Route("/")]
    public class GameController : Controller
    {
        AIHelper player = new AIHelper();
        [HttpPost]
        public string Index([FromForm]string map)
        {
            GameInfo gameInfo = JsonConvert.DeserializeObject<GameInfo>(map);
            var carte = AIHelper.DeserializeMap(gameInfo.CustomSerializedMap);
            StartingState state = new StartingState(new HeldItems(false, false, false, false, 0), new StatLevels(0,0,0,0,0),0);
            Brain brain = new Brain(gameInfo,state, carte);
            // INSERT AI CODE HERE.
            MapManager manager = new MapManager(gameInfo, carte);
            string answer = "";
            //if (gameInfo.Player.CarriedResources != gameInfo.Player.CarryingCapacity)
            //    answer = manager.mine();
            //else
            //    answer = manager.GoHome();
            //string answer = AIHelper.CreateMoveAction(new Point(gameInfo.Player.Position.X + 1, gameInfo.Player.Position.Y));
            answer = brain.getNextAction();
            QuickMine.CoutMap(carte);
            Console.Write(answer);
            Console.Write('\n');
            return answer;
        }
    }
}
