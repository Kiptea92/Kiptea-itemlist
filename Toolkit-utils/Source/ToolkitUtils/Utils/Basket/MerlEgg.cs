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

using RimWorld;
using TwitchToolkit;
using TwitchToolkit.Incidents;
using Verse;
using IncidentDefOf = SirRandoo.ToolkitUtils.IncidentDefOf;

namespace SirRandoo.ToolkitUtils.Utils.Basket;

public record MerlEgg(string? UserId = "BoxFoxMerl") : EasterEgg(UserId)
{
    public override bool IsPossible(StoreIncident incident, Viewer viewer) => incident == IncidentDefOf.BuyPawn && base.IsPossible(incident, viewer);

    public override void Execute(Viewer viewer, Pawn pawn)
    {
        Pawn pet = PawnGenerator.GeneratePawn(new PawnGenerationRequest(PawnKindDef.Named("Husky"), Faction.OfPlayer, fixedBirthName: "Scav", fixedGender: Gender.Male));

        pet.training.Train(TrainableDefOf.Tameness, pawn, true);
        pawn.relations.AddDirectRelation(PawnRelationDefOf.Bond, pet);

        GenSpawn.Spawn(pet, pawn.Position, pawn.Map, pawn.Rotation);
    }
}
