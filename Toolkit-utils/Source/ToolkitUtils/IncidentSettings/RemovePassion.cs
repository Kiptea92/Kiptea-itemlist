﻿// ToolkitUtils
// Copyright (C) 2021  SirRandoo
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using JetBrains.Annotations;
using SirRandoo.ToolkitUtils.Interfaces;
using SirRandoo.ToolkitUtils.Windows;
using ToolkitUtils.UX;
using TwitchToolkit.Incidents;
using UnityEngine;
using Verse;

namespace SirRandoo.ToolkitUtils.IncidentSettings;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
public class RemovePassion : IncidentHelperVariablesSettings, IEventSettings
{
    public static bool Randomness = true;
    public static int ChanceToFail = 20;
    public static int ChanceToHop = 10;
    public static int ChanceToIncrease = 5;
    private string _failChanceBuffer;
    private string _hopChanceBuffer;
    private string _increaseChanceBuffer;

    public int LineSpan => 4;

    public void Draw(Rect canvas, float preferredHeight)
    {
        var listing = new Listing_Standard();
        listing.Begin(canvas);

        listing.CheckboxLabeled("TKUtils.Passion.Randomness.Label".TranslateSimple(), ref Randomness, "TKUtils.Passion.Randomness.Description".TranslateSimple());

        (Rect failLabel, Rect failField) = listing.GetRect(preferredHeight).Split();
        LabelDrawer.Draw(failLabel, "TKUtils.Passion.FailChance.Label".TranslateSimple());
        Widgets.TextFieldNumeric(failField, ref ChanceToFail, ref _failChanceBuffer, max: 100f);
        TooltipHandler.TipRegion(failField, "TKUtils.Passion.FailChance.Description".TranslateSimple());

        (Rect hopLabel, Rect hopField) = listing.GetRect(preferredHeight).Split();
        LabelDrawer.Draw(hopLabel, "TKUtils.Passion.HopChance.Label".TranslateSimple());
        Widgets.TextFieldNumeric(hopField, ref ChanceToHop, ref _hopChanceBuffer, max: 100f);
        TooltipHandler.TipRegion(hopLabel, "TKUtils.Passion.HopChance.Description".TranslateSimple());

        (Rect increaseLabel, Rect increaseField) = listing.GetRect(preferredHeight).Split();
        LabelDrawer.Draw(increaseLabel, "TKUtils.Passion.DecreaseChance.Label".TranslateSimple());
        Widgets.TextFieldNumeric(increaseField, ref ChanceToIncrease, ref _increaseChanceBuffer, max: 100f);
        TooltipHandler.TipRegion(increaseLabel, "TKUtils.Passion.IncreaseChance.Description".TranslateSimple());

        listing.End();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref Randomness, "removePassionRandomness", true);
        Scribe_Values.Look(ref ChanceToFail, "removePassionFailChance", 20);
        Scribe_Values.Look(ref ChanceToHop, "removePassionHopChance", 10);
        Scribe_Values.Look(ref ChanceToIncrease, "removePassionIncreaseChance", 5);
    }

    public override void EditSettings()
    {
        Find.WindowStack.Add(new EventSettingsDialog(this));
    }
}
