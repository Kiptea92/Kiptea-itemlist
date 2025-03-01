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
using RimWorld;
using SirRandoo.ToolkitUtils.IncidentSettings;
using SirRandoo.ToolkitUtils.Interfaces;
using TwitchToolkit.Incidents;

namespace SirRandoo.ToolkitUtils.Models.IncidentDatas;

public class ManhunterPackIncidentData : IWageredIncidentData
{
    public bool UseStoryteller => ManhunterPack.Storyteller;
    public Type WorkerClass => RimWorld.IncidentDefOf.ManhunterPack.workerClass;

    public IncidentCategoryDef ResolveCategory(IncidentWorker worker, StoreIncident incident) => IncidentCategoryDefOf.ThreatSmall;

    public void DoExtraSetup(IncidentWorker worker, IncidentParms @params, StoreIncident incident)
    {
        worker.def = RimWorld.IncidentDefOf.RaidEnemy;
    }
}
