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
using SirRandoo.ToolkitUtils.Interfaces;
using SirRandoo.ToolkitUtils.Models.Tables;
using ToolkitUtils.UX;
using UnityEngine;
using Verse;

namespace SirRandoo.ToolkitUtils.Models.Mutators;

public class AddPriceMutator : IMutatorBase<TraitItem>
{
    private int _addPrice = 1;
    private string _addPriceBuffer = "1";
    private string _addPriceText;
    private bool _percentage;
    private string _percentTooltip;
    private string _valueTooltip;

    public int Priority => 1;

    public string Label => "TKUtils.Fields.AddPrice".TranslateSimple();

    public void Prepare()
    {
        _addPriceText = Label;
        _valueTooltip = "TKUtils.MutatorTooltips.ValuePrice".TranslateSimple();
        _percentTooltip = "TKUtils.MutatorTooltips.PercentPrice".TranslateSimple();
    }

    public void Mutate(TableSettingsItem<TraitItem> item)
    {
        item.Data.CostToAdd = _percentage ? Mathf.CeilToInt(item.Data.CostToAdd * (_addPrice / 100f)) : _addPrice;
    }

    public void Draw(Rect canvas)
    {
        (Rect label, Rect field) = canvas.Split(0.75f);
        LabelDrawer.Draw(label, _addPriceText);
        Widgets.TextFieldNumeric(field, ref _addPrice, ref _addPriceBuffer, _percentage ? -100f : 1f);

        if (ButtonDrawer.DrawFieldButton(field, _percentage ? "%" : "#", _percentage ? _percentTooltip : _valueTooltip))
        {
            _percentage = !_percentage;
        }
    }
}
