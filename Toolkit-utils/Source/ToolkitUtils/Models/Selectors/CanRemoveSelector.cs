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

using SirRandoo.ToolkitUtils.Interfaces;
using SirRandoo.ToolkitUtils.Models.Tables;
using SirRandoo.ToolkitUtils.Utils;
using ToolkitUtils.UX;
using UnityEngine;
using Verse;

namespace SirRandoo.ToolkitUtils.Models.Selectors;

public class CanRemoveSelector : ISelectorBase<TraitItem>
{
    private string? _canRemoveText;
    private bool _state = true;

    public void Prepare()
    {
        _canRemoveText = Label;
    }

    public void Draw(Rect canvas)
    {
        if (CheckboxDrawer.DrawCheckbox(canvas, _canRemoveText, ref _state))
        {
            Dirty.Set(true);
        }
    }

    public ObservableProperty<bool> Dirty { get; set; }

    public bool IsVisible(TableSettingsItem<TraitItem> item) => item.Data.CanRemove == _state;

    public string? Label => "TKUtils.Fields.CanRemove".TranslateSimple();
}
