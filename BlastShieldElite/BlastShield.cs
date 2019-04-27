using System;
using System.Collections.Generic;
using System.Linq;
using InfinityScript;

namespace BlastShield
{
    public class BlastShield : BaseScript
    {
        public override void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc)
        {
            if (dFlags == 16)//16 is Stun? if dFLags count as idFlags. If not, use: if weapon == "concussion_grenade_mp"
            {
                if (player.Call<bool>("hasperk", "specialty_stun_resistance"))
                {
                    //player = stunned player
                    AfterDelay(1000, () =>//We'll need to fix this up. Time this out for a safe cancel.
                        {
                            player.Call("stopshellshock");
                            //player.Call("fadeoutshellshock");Use if above is obvious
                        });
                }
            }
        }
    }
}
