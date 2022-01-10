using System.Collections.Generic;
using Dalamud.Game.Text.SeStringHandling.Payloads;

namespace HuntBuddy
{
	public static class LocationDb
	{
		public class PositionInfo
		{
			public float X { get; set; }
			public float Y { get; set; }
		}

		// MobHuntId as key
		public static readonly Dictionary<uint, PositionInfo> Database = new()
		{
			// Shadowbringers
			// Lakeland
			{ 08498, new PositionInfo { X = 19.0f, Y = 09.0f } }, // Chiliad Cama
			{ 08502, new PositionInfo { X = 28.0f, Y = 23.2f } }, // Violet Triffid
			{ 08503, new PositionInfo { X = 14.0f, Y = 16.5f } }, // Gnole
			{ 08504, new PositionInfo { X = 24.4f, Y = 23.9f } }, // Wetland Warg
			{ 08505, new PositionInfo { X = 33.2f, Y = 10.0f } }, // White Gremlin
			{ 08507, new PositionInfo { X = 25.8f, Y = 23.3f } }, // Hoptrap
			{ 08508, new PositionInfo { X = 28.5f, Y = 36.7f } }, // Wolverine
			{ 08511, new PositionInfo { X = 11.3f, Y = 11.0f } }, // Smilodon
			{ 08514, new PositionInfo { X = 34.2f, Y = 17.0f } }, // Ya-te-veo
			{ 08515, new PositionInfo { X = 29.0f, Y = 17.6f } }, // Proterosuchus
			{ 08786, new PositionInfo { X = 20.5f, Y = 25.3f } }, // Lake Viper

			// Kholusia
			{ 08517, new PositionInfo { X = 31.9f, Y = 18.9f } }, // Ironbeard
			{ 08518, new PositionInfo { X = 36.4f, Y = 28.7f } }, // Hobgoblin
			{ 08520, new PositionInfo { X = 17.0f, Y = 18.0f } }, // Defective Talos
			{ 08522, new PositionInfo { X = 34.8f, Y = 10.5f } }, // Sulfur Byrgen
			{ 08523, new PositionInfo { X = 35.4f, Y = 29.2f } }, // Maultasche
			{ 08524, new PositionInfo { X = 14.3f, Y = 11.4f } }, // Huldu
			{ 08525, new PositionInfo { X = 14.3f, Y = 27.1f } }, // Island Rail
			{ 08527, new PositionInfo { X = 17.0f, Y = 11.0f } }, // Cliffkite
			{ 08528, new PositionInfo { X = 27.1f, Y = 13.8f } }, // Cliffmole
			{ 08529, new PositionInfo { X = 08.0f, Y = 18.0f } }, // Scree Gnome
			{ 08532, new PositionInfo { X = 17.8f, Y = 26.5f } }, // Wood Eyes
			{ 08533, new PositionInfo { X = 25.0f, Y = 23.5f } }, // Island Wolf
			{ 08534, new PositionInfo { X = 10.1f, Y = 29.6f } }, // Kholusian Bison
			{ 08536, new PositionInfo { X = 32.5f, Y = 26.2f } }, // Whiptail
			{ 08538, new PositionInfo { X = 22.5f, Y = 09.6f } }, // Highland Hyssop
			{ 08539, new PositionInfo { X = 19.9f, Y = 33.0f } }, // Tragopan
			{ 08540, new PositionInfo { X = 13.0f, Y = 15.0f } }, // Saichania
			{ 08541, new PositionInfo { X = 21.0f, Y = 08.7f } }, // Gulgnu
			{ 08542, new PositionInfo { X = 21.6f, Y = 32.0f } }, // Germinant

			// Amh Araeng
			{ 08544, new PositionInfo { X = 11.4f, Y = 30.4f } }, // Masterless Talos
			{ 08545, new PositionInfo { X = 19.1f, Y = 20.9f } }, // Evil Weapon
			{ 08547, new PositionInfo { X = 30.4f, Y = 12.3f } }, // Gigantender
			{ 08550, new PositionInfo { X = 30.1f, Y = 27.2f } }, // Ancient Lizard
			{ 08556, new PositionInfo { X = 29.4f, Y = 21.7f } }, // Sand Mole
			{ 08557, new PositionInfo { X = 12.7f, Y = 19.0f } }, // Thistle Mole
			{ 08558, new PositionInfo { X = 30.9f, Y = 27.3f } }, // Scissorjaws
			{ 08559, new PositionInfo { X = 21.5f, Y = 09.7f } }, // Gnome
			{ 08561, new PositionInfo { X = 13.9f, Y = 18.2f } }, // Debitage
			{ 08562, new PositionInfo { X = 27.1f, Y = 29.6f } }, // Ghilman
			{ 08563, new PositionInfo { X = 25.0f, Y = 34.3f } }, // Flame Zonure
			{ 08565, new PositionInfo { X = 15.2f, Y = 16.7f } }, // Phorusrhacos
			{ 08566, new PositionInfo { X = 21.7f, Y = 09.8f } }, // Desert Coyote
			{ 08567, new PositionInfo { X = 23.9f, Y = 31.8f } }, // Molamander

			// Il Mheg
			{ 08155, new PositionInfo { X = 08.4f, Y = 30.0f } }, // Flower Basket
			{ 08569, new PositionInfo { X = 18.0f, Y = 31.0f } }, // Echevore
			{ 08574, new PositionInfo { X = 31.0f, Y = 14.3f } }, // Garden Porxie
			{ 08575, new PositionInfo { X = 19.9f, Y = 16.3f } }, // Phooka
			{ 08576, new PositionInfo { X = 11.1f, Y = 26.0f } }, // Etainmoth
			{ 08577, new PositionInfo { X = 29.4f, Y = 12.7f } }, // Green Glider
			{ 08578, new PositionInfo { X = 21.0f, Y = 08.8f } }, // Moss Fungus
			{ 08581, new PositionInfo { X = 07.8f, Y = 18.7f } }, // Hawker
			{ 08582, new PositionInfo { X = 25.0f, Y = 11.0f } }, // Rainbow Lorikeet
			{ 08583, new PositionInfo { X = 29.5f, Y = 11.4f } }, // Tot Aevis
			{ 08584, new PositionInfo { X = 30.4f, Y = 10.6f } }, // Rabbit's Tail
			{ 08585, new PositionInfo { X = 19.0f, Y = 32.0f } }, // Rosebear
			{ 08586, new PositionInfo { X = 31.6f, Y = 06.4f } }, // Garden Crocota
			{ 08587, new PositionInfo { X = 32.0f, Y = 05.8f } }, // Werewood
			{ 08590, new PositionInfo { X = 09.4f, Y = 15.0f } }, // Killer Bee

			// The Rak'tika Greatwood
			{ 08596, new PositionInfo { X = 08.8f, Y = 35.6f } }, // Tomatl
			{ 08597, new PositionInfo { X = 27.3f, Y = 25.6f } }, // Forest Echo
			{ 08598, new PositionInfo { X = 25.1f, Y = 14.2f } }, // Cracked Ronkan Doll
			{ 08599, new PositionInfo { X = 23.0f, Y = 14.0f } }, // Cracked Ronkan Thorn
			{ 08600, new PositionInfo { X = 16.0f, Y = 32.0f } }, // Vampire Vine
			{ 08601, new PositionInfo { X = 23.4f, Y = 07.6f } }, // Greatwood Rail
			{ 08603, new PositionInfo { X = 29.4f, Y = 21.7f } }, // Snapweed
			{ 08604, new PositionInfo { X = 12.0f, Y = 34.0f } }, // Atrociraptor
			{ 08606, new PositionInfo { X = 27.7f, Y = 23.2f } }, // Gizamaluk
			{ 08609, new PositionInfo { X = 16.9f, Y = 33.3f } }, // Helm Beetle
			{ 08610, new PositionInfo { X = 34.1f, Y = 16.5f } }, // Floor Mandrill
			{ 08611, new PositionInfo { X = 15.0f, Y = 19.4f } }, // Wild Swine
			{ 08612, new PositionInfo { X = 24.9f, Y = 30.2f } }, // Caracal
			{ 08614, new PositionInfo { X = 25.0f, Y = 07.2f } }, // Woodbat
			{ 08616, new PositionInfo { X = 27.9f, Y = 21.2f } }, // Tarichuk
			{ 08789, new PositionInfo { X = 21.1f, Y = 13.2f } }, // Cracked Ronkan Vessel

			// The Tempest
			{ 08618, new PositionInfo { X = 28.6f, Y = 06.2f } }, // Clinoid
			{ 08619, new PositionInfo { X = 28.2f, Y = 18.3f } }, // Dagon
			{ 08621, new PositionInfo { X = 22.6f, Y = 31.7f } }, // Cubus
			{ 08622, new PositionInfo { X = 25.1f, Y = 18.6f } }, // Sea Anemone
			{ 08623, new PositionInfo { X = 32.1f, Y = 11.7f } }, // Amphisbaena
			{ 08625, new PositionInfo { X = 32.5f, Y = 21.5f } }, // Morgawr
			{ 08626, new PositionInfo { X = 36.6f, Y = 16.6f } }, // Trilobite
			{ 08629, new PositionInfo { X = 27.7f, Y = 08.7f } }, // Sea Gelatin
			{ 08630, new PositionInfo { X = 29.0f, Y = 21.0f } }, // Tempest Swallow
			{ 08631, new PositionInfo { X = 35.8f, Y = 07.2f } }, // Blue Swimmer


			// Endwalker
			// Labyrinthos
			{ 10668, new PositionInfo { X = 28.8f, Y = 08.8f } }, // Troll
			{ 10669, new PositionInfo { X = 31.0f, Y = 25.5f } }, // Genomos
			{ 10670, new PositionInfo { X = 15.0f, Y = 06.5f } }, // Caribou
			{ 10672, new PositionInfo { X = 32.0f, Y = 08.8f } }, // Limascabra
			{ 10673, new PositionInfo { X = 21.5f, Y = 13.5f } }, // Luncheon Toad
			{ 10674, new PositionInfo { X = 17.0f, Y = 12.0f } }, // Yakow
			{ 10677, new PositionInfo { X = 34.0f, Y = 15.0f } }, // Labyrinth Screamer
			{ 10678, new PositionInfo { X = 24.0f, Y = 10.7f } }, // Northern Snapweed
			{ 10679, new PositionInfo { X = 26.0f, Y = 14.5f } }, // Pephredo
			{ 10683, new PositionInfo { X = 37.5f, Y = 19.5f } }, // Mythrilcap

			// Thavnair
			{ 10697, new PositionInfo { X = 19.0f, Y = 23.9f } }, // Pisaca
			{ 10698, new PositionInfo { X = 13.8f, Y = 18.5f } }, // Vajralangula
			{ 10699, new PositionInfo { X = 19.2f, Y = 32.6f } }, // Kacchapa
			{ 10700, new PositionInfo { X = 18.4f, Y = 26.7f } }, // Hamsa
			{ 10701, new PositionInfo { X = 29.1f, Y = 12.2f } }, // Asvattha
			{ 10702, new PositionInfo { X = 27.1f, Y = 27.8f } }, // Guhasaya
			{ 10703, new PositionInfo { X = 27.0f, Y = 17.4f } }, // Bhujamga
			{ 10704, new PositionInfo { X = 17.6f, Y = 17.8f } }, // Sotormurg
			{ 10705, new PositionInfo { X = 22.7f, Y = 30.4f } }, // Gaja
			{ 10706, new PositionInfo { X = 19.1f, Y = 11.7f } }, // Thavnairian Jhammel
			{ 10707, new PositionInfo { X = 25.9f, Y = 19.0f } }, // Ufiti
			{ 10709, new PositionInfo { X = 09.2f, Y = 12.8f } }, // Chamrosh
			{ 10711, new PositionInfo { X = 16.1f, Y = 09.2f } }, // Starmite
			{ 10712, new PositionInfo { X = 14.3f, Y = 12.7f } }, // Manjusaka
			{ 10713, new PositionInfo { X = 23.3f, Y = 19.9f } }, // Odqan
			{ 10715, new PositionInfo { X = 13.4f, Y = 28.5f } }, // Akyaali Crab
			{ 10716, new PositionInfo { X = 08.2f, Y = 16.2f } }, // Valras

			// Garlemald
			{ 10648, new PositionInfo { X = 18.8f, Y = 09.8f } }, // Automated Satellite
			{ 10649, new PositionInfo { X = 25.5f, Y = 17.5f } }, // Automated Death Machine
			{ 10650, new PositionInfo { X = 15.5f, Y = 19.5f } }, // Automated Cavalry
			{ 10651, new PositionInfo { X = 21.8f, Y = 17.4f } }, // Automated Bit
			{ 10652, new PositionInfo { X = 15.7f, Y = 09.8f } }, // Automated Roader
			{ 10653, new PositionInfo { X = 29.5f, Y = 13.7f } }, // Automated Slasher
			{ 10654, new PositionInfo { X = 24.3f, Y = 14.9f } }, // Automated Colossus
			{ 10655, new PositionInfo { X = 12.9f, Y = 11.7f } }, // Automated Avenger
			{ 10656, new PositionInfo { X = 29.6f, Y = 30.3f } }, // Almasty
			{ 10657, new PositionInfo { X = 14.6f, Y = 26.1f } }, // Eblan Bear
			{ 10658, new PositionInfo { X = 31.3f, Y = 17.4f } }, // Eblan Icetrap
			{ 10659, new PositionInfo { X = 19.8f, Y = 29.1f } }, // Ovibos
			{ 10660, new PositionInfo { X = 22.3f, Y = 24.9f } }, // Jotunn
			{ 10661, new PositionInfo { X = 28.4f, Y = 33.0f } }, // Ceruleum Zoblyn
			{ 10662, new PositionInfo { X = 25.4f, Y = 31.5f } }, // Ilsabardian Tursus
			{ 10663, new PositionInfo { X = 18.7f, Y = 24.8f } }, // Canis Lupinus
			{ 10664, new PositionInfo { X = 26.1f, Y = 26.5f } }, // Overgrown Rose

			// Mare Lamentorum
			{ 10458, new PositionInfo { X = 23.9f, Y = 20.0f } }, // Daphnia
			{ 10459, new PositionInfo { X = 23.7f, Y = 20.3f } }, // Osculator
			{ 10460, new PositionInfo { X = 08.6f, Y = 35.5f } }, // Sweeper
			{ 10461, new PositionInfo { X = 27.3f, Y = 26.0f } }, // Wanderer
			{ 10462, new PositionInfo { X = 31.1f, Y = 32.2f } }, // Weeper
			{ 10463, new PositionInfo { X = 19.8f, Y = 22.5f } }, // Thinker
			{ 10464, new PositionInfo { X = 26.0f, Y = 34.0f } }, // Regolith
			{ 10465, new PositionInfo { X = 21.4f, Y = 32.2f } }, // Trimmer
			{ 10467, new PositionInfo { X = 12.0f, Y = 36.7f } }, // Panopt
			{ 10468, new PositionInfo { X = 11.5f, Y = 22.3f } }, // Dynamite
			{ 10469, new PositionInfo { X = 16.7f, Y = 31.8f } }, // Armalcolite
			{ 10470, new PositionInfo { X = 12.9f, Y = 09.6f } }, // Caretaker
			{ 10471, new PositionInfo { X = 16.1f, Y = 24.9f } }, // Mousse
			{ 10473, new PositionInfo { X = 31.2f, Y = 27.0f } }, // Downfall Alarum
			{ 10474, new PositionInfo { X = 33.6f, Y = 26.2f } }, // Downfall Droid
			{ 10475, new PositionInfo { X = 34.5f, Y = 28.0f } }, // Downfall Hunter
			{ 10476, new PositionInfo { X = 13.0f, Y = 10.0f } }, // Supporter
			{ 10477, new PositionInfo { X = 30.1f, Y = 11.0f } }, // Scraper

			// Elpis
			{ 10590, new PositionInfo { X = 25.7f, Y = 33.9f } }, // Ophion
			{ 10591, new PositionInfo { X = 16.5f, Y = 29.9f } }, // Yggdreant
			{ 10592, new PositionInfo { X = 22.6f, Y = 20.0f } }, // Okyupete
			{ 10594, new PositionInfo { X = 12.4f, Y = 31.8f } }, // Gryps
			{ 10595, new PositionInfo { X = 26.6f, Y = 29.7f } }, // Monoceros
			{ 10596, new PositionInfo { X = 10.1f, Y = 14.1f } }, // Pegasos
			{ 10597, new PositionInfo { X = 28.7f, Y = 25.6f } }, // Bird of Elpis
			{ 10599, new PositionInfo { X = 33.4f, Y = 14.3f } }, // Hippe
			{ 10600, new PositionInfo { X = 14.1f, Y = 09.9f } }, // Harpuia
			{ 10601, new PositionInfo { X = 25.0f, Y = 10.0f } }, // Morbol Marquis
			{ 10602, new PositionInfo { X = 29.2f, Y = 09.3f } }, // Akantha
			{ 10603, new PositionInfo { X = 24.4f, Y = 14.3f } }, // Lykopersikon
			{ 10606, new PositionInfo { X = 21.5f, Y = 06.3f } }, // Lotis
			{ 10607, new PositionInfo { X = 10.2f, Y = 34.6f } }, // Phanopsyche
			{ 10608, new PositionInfo { X = 12.9f, Y = 23.4f } }, // Melanion
			{ 10609, new PositionInfo { X = 12.9f, Y = 08.7f } }, // Ophiotauros
			{ 10610, new PositionInfo { X = 13.3f, Y = 15.7f } }, // Elpis Minotaur
			{ 10611, new PositionInfo { X = 30.7f, Y = 17.1f } }, // Remora

			// Ultima Thule
			{ 10419, new PositionInfo { X = 30.1f, Y = 25.9f } }, // Broken Omicron
			{ 10420, new PositionInfo { X = 19.3f, Y = 11.8f } }, // Drifting Ea
			{ 10421, new PositionInfo { X = 34.8f, Y = 28.8f } }, // Beta
			{ 10422, new PositionInfo { X = 32.9f, Y = 28.8f } }, // Delta
			{ 10423, new PositionInfo { X = 36.5f, Y = 25.9f } }, // Lambda
			{ 10424, new PositionInfo { X = 32.1f, Y = 26.6f } }, // Level Tricker
			{ 10427, new PositionInfo { X = 10.0f, Y = 30.0f } }, // Stellar Amphiptere
			{ 10430, new PositionInfo { X = 14.4f, Y = 28.2f } }, // Stellar Brobinyak
			{ 10435, new PositionInfo { X = 16.3f, Y = 14.1f } }, // Other One
		};

		public static void OpenMapLink(uint territoryType, uint mapId, uint mobHuntId)
		{
			var mapLinkPayload = new MapLinkPayload(territoryType, mapId, Database[mobHuntId].X, Database[mobHuntId].Y);
			Plugin.GameGui.OpenMapWithMapLink(mapLinkPayload);
		}
	}
}