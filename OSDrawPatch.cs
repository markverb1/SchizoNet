using Hacknet;
using Hacknet.Effects;
using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schizo
{
    [HarmonyPatch(typeof(PostProcessor), nameof(PostProcessor.end))]
    public class OSDrawPatch
    {
        static bool Prefix()
        {
            PostProcessor.device.SetRenderTarget(PostProcessor.backTarget);
            PostProcessor.sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullNone, PostProcessor.blur);
            PostProcessor.sb.Draw(PostProcessor.target, Vector2.Zero, Color.White);
            PostProcessor.sb.End();
            RenderTarget2D renderTarget = PostProcessor.dangerModeEnabled ? PostProcessor.dangerBufferTarget : null;
            PostProcessor.device.SetRenderTarget(renderTarget);
            if (ScreenGlitch.sEnabled)
            {
                PostProcessor.device.Clear(Color.Black);
            }
            PostProcessor.sb.Begin();
            Rectangle fullscreenRect = PostProcessor.GetFullscreenRect();
            if (ScreenGlitch.sEnabled)
            {
                FlickeringTextEffect.DrawFlickeringSprite(PostProcessor.sb, fullscreenRect, PostProcessor.target, ScreenGlitch.sIntensity, ScreenGlitch.sDelay, null, Color.White);
            }
            else
            {
                PostProcessor.sb.Draw(PostProcessor.target, fullscreenRect, Color.White);
            }
            if (PostProcessor.bloomEnabled)
            {
                PostProcessor.sb.Draw(PostProcessor.backTarget, fullscreenRect, PostProcessor.bloomColor);
            }
            else
            {
                PostProcessor.sb.Draw(PostProcessor.target, fullscreenRect, PostProcessor.bloomAbsenceHighlighterColor);
            }
            PostProcessor.sb.End();
            if (PostProcessor.dangerModeEnabled)
            {
                PostProcessor.DrawDangerModeFliters();
            }

            return false;
        }
    }
}