using Sandbox.Game.Components;
using Sandbox.ModAPI;

namespace ExtendedSurvival.Stats
{

    public abstract class MyStatSimpleProgressBase : MyBaseStatSimpleProgressBase
    {

        protected override MyEntityStatComponent GetStatComp()
        {
            return MyAPIGateway.Session.Player?.Character?.Components.Get<MyEntityStatComponent>();
        }

    }

}