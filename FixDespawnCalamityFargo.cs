using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FixDespawnCalamityFargo
{
    public class InstantBossDespawnSystem : ModSystem
    {
        public override void PostUpdateNPCs()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            // Проверяем, есть ли живые игроки
            bool anyPlayerAlive = Main.player.Any(p => p != null && p.active && !p.dead);

            if (!anyPlayerAlive)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active && (npc.boss || npc.realLife >= 0))
                    {
                        // 1. Сбрасываем время жизни до 0, чтобы моды поняли, что пора уходить
                        npc.timeLeft = 0;
                        
                        // 2. Вызываем стандартный безопасный деспавн tModLoader
                        npc.EncourageDespawn(0);

                        // 3. Если босс всё равно "упрямится" и не исчезает мгновенно — применяем жесткую очистку
                        npc.active = false;

                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, i);
                        }
                    }
                }
            }
        }
    }
}