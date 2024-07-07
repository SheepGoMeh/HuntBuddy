using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using FFXIVClientStructs.FFXIV.Client.UI.Agent;

using Lumina.Excel.GeneratedSheets;

using MapType = FFXIVClientStructs.FFXIV.Client.UI.Agent.MapType;

namespace HuntBuddy;

public static class Location {
	public class PositionInfo {
		public float X {
			get;
			init;
		}

		public float Y {
			get;
			init;
		}

		public Vector2 Coordinate => new(this.X, this.Y);
	}

	// MobHuntId as key
	public static readonly Dictionary<uint, PositionInfo> Database = new() {
		// Heavensward
		// Coerthas Western Highlands
		{ 03481, new PositionInfo { X = 15.0f, Y = 12.0f } }, // Archaeornis
		{ 03472, new PositionInfo { X = 32.0f, Y = 24.0f } }, // Bergthurs
		{ 03471, new PositionInfo { X = 30.0f, Y = 31.0f } }, // Deepeye
		{ 03476, new PositionInfo { X = 28.0f, Y = 12.0f } }, // Frost Grenade
		{ 03480, new PositionInfo { X = 11.0f, Y = 17.0f } }, // Gelato
		{ 03484, new PositionInfo { X = 10.0f, Y = 14.0f } }, // Ice Commander
		{ 03475, new PositionInfo { X = 23.0f, Y = 16.0f } }, // Icetrap
		{ 03487, new PositionInfo { X = 28.0f, Y = 09.0f } }, // Inland Tursus
		{ 03483, new PositionInfo { X = 19.0f, Y = 29.0f } }, // Lone Yeti
		{ 03485, new PositionInfo { X = 22.0f, Y = 21.0f } }, // Polar Bear
		{ 03482, new PositionInfo { X = 16.0f, Y = 20.0f } }, // Rheum
		{ 03473, new PositionInfo { X = 26.0f, Y = 24.0f } }, // Silver Wolf
		{ 03490, new PositionInfo { X = 25.0f, Y = 32.0f } }, // Slate Yeti
		{ 03478, new PositionInfo { X = 25.0f, Y = 12.0f } }, // Slush Zoblyn
		{ 03470, new PositionInfo { X = 30.0f, Y = 32.0f } }, // Steinbock
		{ 03474, new PositionInfo { X = 31.0f, Y = 20.0f } }, // Upland Mylodon
		{ 03493, new PositionInfo { X = 09.0f, Y = 09.0f } }, // Vindthurs
		{ 03479, new PositionInfo { X = 15.0f, Y = 17.0f } }, // Wooly Yak

		// The Sea of Clouds
		{ 03524, new PositionInfo { X = 21.0f, Y = 06.0f } }, // Anzu
		{ 03498, new PositionInfo { X = 28.0f, Y = 29.0f } }, // Cloudworm
		{ 03496, new PositionInfo { X = 27.0f, Y = 30.0f } }, // Conodont
		{ 03505, new PositionInfo { X = 19.0f, Y = 30.0f } }, // Dhalmel
		{ 03511, new PositionInfo { X = 17.0f, Y = 10.0f } }, // Endymion
		{ 03494, new PositionInfo { X = 11.0f, Y = 33.0f } }, // Gaelicat
		{ 03495, new PositionInfo { X = 16.0f, Y = 36.0f } }, // Gastornis
		{ 03512, new PositionInfo { X = 23.0f, Y = 09.0f } }, // Groundskeeper
		{ 03506, new PositionInfo { X = 20.0f, Y = 30.0f } }, // Korrigan
		{ 03501, new PositionInfo { X = 36.0f, Y = 24.0f } }, // Lan'laii Gundu
		{ 03502, new PositionInfo { X = 36.0f, Y = 20.0f } }, // Nat'laii Gundu
		{ 03516, new PositionInfo { X = 28.0f, Y = 10.0f } }, // Nat'laii Vundu
		{ 03497, new PositionInfo { X = 29.0f, Y = 30.0f } }, // Obdella
		{ 03499, new PositionInfo { X = 20.0f, Y = 34.0f } }, // Paissa
		{ 03500, new PositionInfo { X = 36.0f, Y = 24.0f } }, // Sanuwa
		{ 03514, new PositionInfo { X = 30.0f, Y = 14.0f } }, // Sanuwa Vundu
		{ 03525, new PositionInfo { X = 21.0f, Y = 07.0f } }, // Toco Toco
		{ 03523, new PositionInfo { X = 14.0f, Y = 07.0f } }, // Tsanahale
		{ 03503, new PositionInfo { X = 35.0f, Y = 25.0f } }, // Vuk'laii Gundu
		{ 03513, new PositionInfo { X = 18.0f, Y = 17.0f } }, // Vundu Totem
		{ 03509, new PositionInfo { X = 09.0f, Y = 16.0f } }, // Window Wamoura
		{ 03510, new PositionInfo { X = 10.0f, Y = 17.0f } }, // Window Wamouracampa
		{ 03504, new PositionInfo { X = 20.0f, Y = 38.0f } }, // Wisent

		// The Dravanian Forelands
		{ 03565, new PositionInfo { X = 30.0f, Y = 16.0f } }, // Bandersnatch
		{ 03566, new PositionInfo { X = 26.0f, Y = 11.0f } }, // Brown Bear
		{ 03570, new PositionInfo { X = 28.0f, Y = 22.0f } }, // Clearwater Nanka
		{ 03569, new PositionInfo { X = 27.0f, Y = 25.0f } }, // Clearwater Ninki Nanka
		{ 03572, new PositionInfo { X = 28.0f, Y = 32.0f } }, // Dragonfly Watcher
		{ 03567, new PositionInfo { X = 27.0f, Y = 22.0f } }, // Dravanian Aevis
		{ 03576, new PositionInfo { X = 16.0f, Y = 33.0f } }, // Dravanian Wyvern
		{ 03563, new PositionInfo { X = 36.0f, Y = 24.0f } }, // Feather Flea
		{ 03578, new PositionInfo { X = 17.0f, Y = 26.0f } }, // Forelands Hippocerf
		{ 03579, new PositionInfo { X = 18.0f, Y = 12.0f } }, // Gallimimus
		{ 03571, new PositionInfo { X = 25.0f, Y = 29.0f } }, // Loaghtan
		{ 03592, new PositionInfo { X = 27.0f, Y = 35.0f } }, // Loth Cultivator
		{ 03590, new PositionInfo { X = 27.0f, Y = 35.0f } }, // Loth Firedrone
		{ 03591, new PositionInfo { X = 29.0f, Y = 36.0f } }, // Loth Steeldrone
		{ 03568, new PositionInfo { X = 28.0f, Y = 25.0f } }, // Melia
		{ 03577, new PositionInfo { X = 18.0f, Y = 31.0f } }, // Miacid
		{ 03555, new PositionInfo { X = 18.0f, Y = 12.0f } }, // Syricta
		{ 03586, new PositionInfo { X = 31.0f, Y = 08.0f } }, // Thunder Dragon
		{ 03582, new PositionInfo { X = 13.0f, Y = 15.0f } }, // Tyrannosaur
		{ 03581, new PositionInfo { X = 13.0f, Y = 14.0f } }, // Vinegaroon
		{ 03564, new PositionInfo { X = 35.0f, Y = 21.0f } }, // Wild Chocobo

		// The Churning Mists
		{ 03619, new PositionInfo { X = 17.0f, Y = 27.0f } }, // Amphiptere
		{ 03620, new PositionInfo { X = 24.0f, Y = 26.0f } }, // Archaeosaur
		{ 03625, new PositionInfo { X = 18.0f, Y = 24.0f } }, // Bladed Vinegaroon
		{ 03630, new PositionInfo { X = 25.0f, Y = 10.0f } }, // Blood Dragon
		{ 03631, new PositionInfo { X = 09.0f, Y = 36.0f } }, // Cloud Aevis
		{ 03629, new PositionInfo { X = 08.0f, Y = 19.0f } }, // Diresaur
		{ 03623, new PositionInfo { X = 20.0f, Y = 12.0f } }, // Dragonet
		{ 03626, new PositionInfo { X = 34.0f, Y = 21.0f } }, // Elder Syricta
		{ 03628, new PositionInfo { X = 25.0f, Y = 30.0f } }, // Elder Wyvern
		{ 03668, new PositionInfo { X = 10.0f, Y = 20.0f } }, // Gnarled Melia
		{ 03614, new PositionInfo { X = 34.0f, Y = 28.0f } }, // Hropken
		{ 03621, new PositionInfo { X = 09.0f, Y = 12.0f } }, // Limestone Golem
		{ 03618, new PositionInfo { X = 20.0f, Y = 28.0f } }, // Lower Skylord
		{ 03627, new PositionInfo { X = 33.0f, Y = 31.0f } }, // Mists Biast
		{ 03622, new PositionInfo { X = 10.0f, Y = 18.0f } }, // Mists Drake
		{ 03617, new PositionInfo { X = 23.0f, Y = 25.0f } }, // Moss Dragon
		{ 03613, new PositionInfo { X = 28.0f, Y = 32.0f } }, // Sankchinni
		{ 03615, new PositionInfo { X = 32.0f, Y = 15.0f } }, // Tulihand
		{ 03624, new PositionInfo { X = 38.0f, Y = 17.7f } }, // Vouivre
		{ 03616, new PositionInfo { X = 26.0f, Y = 20.0f } }, // Wadjet

		// The Dravanian Hinterlands
		{ 03612, new PositionInfo { X = 25.0f, Y = 37.0f } }, // Bifericeras
		{ 03609, new PositionInfo { X = 18.0f, Y = 36.0f } }, // Cockatrice
		{ 03603, new PositionInfo { X = 12.0f, Y = 16.0f } }, // Crawler
		{ 03594, new PositionInfo { X = 24.0f, Y = 21.0f } }, // Damselfly
		{ 03598, new PositionInfo { X = 31.0f, Y = 22.0f } }, // Goblin Brandisher
		{ 03601, new PositionInfo { X = 31.0f, Y = 22.0f } }, // Goblin Glider
		{ 03600, new PositionInfo { X = 31.0f, Y = 22.0f } }, // Goblin Sharpshooter
		{ 03599, new PositionInfo { X = 31.0f, Y = 22.0f } }, // Goblin Tinkerer
		{ 03605, new PositionInfo { X = 10.0f, Y = 21.0f } }, // Great Morbol
		{ 03597, new PositionInfo { X = 37.0f, Y = 24.0f } }, // Narbrooi
		{ 03610, new PositionInfo { X = 17.0f, Y = 33.0f } }, // Okeanis
		{ 03608, new PositionInfo { X = 12.0f, Y = 33.0f } }, // Opken
		{ 03604, new PositionInfo { X = 11.0f, Y = 27.0f } }, // Orn Kite
		{ 03607, new PositionInfo { X = 09.0f, Y = 34.0f } }, // Poroggo
		{ 03595, new PositionInfo { X = 28.0f, Y = 27.0f } }, // Ratel
		{ 03611, new PositionInfo { X = 12.0f, Y = 32.0f } }, // Sun Leech
		{ 03593, new PositionInfo { X = 21.0f, Y = 16.0f } }, // Tarantula Hawk
		{ 03596, new PositionInfo { X = 34.0f, Y = 19.0f } }, // Wildebeest

		// Azys Lla
		{ 03545, new PositionInfo { X = 35.0f, Y = 24.0f } }, // 6th Legion Vanguard
		{ 03552, new PositionInfo { X = 27.0f, Y = 33.0f } }, // Adamantite Claw
		{ 03540, new PositionInfo { X = 31.0f, Y = 06.0f } }, // Allagan Chimera
		{ 03534, new PositionInfo { X = 15.0f, Y = 13.0f } }, // Clockwork Engineer
		{ 03536, new PositionInfo { X = 13.0f, Y = 08.0f } }, // Clockwork Harvestman
		{ 03535, new PositionInfo { X = 18.0f, Y = 13.0f } }, // Clockwork Paladin
		{ 03542, new PositionInfo { X = 35.0f, Y = 09.0f } }, // Corpse Flower
		{ 03541, new PositionInfo { X = 29.5f, Y = 12.0f } }, // Empuse
		{ 03537, new PositionInfo { X = 13.0f, Y = 17.0f } }, // Enforcement Droid
		{ 03539, new PositionInfo { X = 27.0f, Y = 11.0f } }, // Lamia Cybrid
		{ 03538, new PositionInfo { X = 28.0f, Y = 13.0f } }, // Lamia Thelytoke
		{ 03580, new PositionInfo { X = 13.0f, Y = 33.0f } }, // Lesser Hydra
		{ 03559, new PositionInfo { X = 18.0f, Y = 31.0f } }, // Meracydian Amphiptere
		{ 03557, new PositionInfo { X = 08.0f, Y = 32.0f } }, // Meracydian Brobinyak
		{ 03560, new PositionInfo { X = 08.0f, Y = 27.0f } }, // Meracydian Dragon
		{ 03558, new PositionInfo { X = 06.0f, Y = 35.0f } }, // Meracydian Dragonet
		{ 03554, new PositionInfo { X = 15.0f, Y = 29.0f } }, // Meracydian Falak
		{ 03556, new PositionInfo { X = 14.0f, Y = 35.0f } }, // Meracydian Vouivre
		{ 03533, new PositionInfo { X = 12.0f, Y = 15.0f } }, // Owlbear
		{ 03543, new PositionInfo { X = 35.0f, Y = 08.0f } }, // Proto-naga
		{ 03544, new PositionInfo { X = 33.0f, Y = 13.0f } }, // Reptoid
		{ 03532, new PositionInfo { X = 09.0f, Y = 12.0f } }, // Snapper-rook

		// Stormblood
		// The Fringes
		{ 05685, new PositionInfo { X = 10.0f, Y = 27.0f } }, // Diakka
		{ 05674, new PositionInfo { X = 22.0f, Y = 16.0f } }, // Foper
		{ 05697, new PositionInfo { X = 25.0f, Y = 27.0f } }, // Gazelle
		{ 05676, new PositionInfo { X = 11.6f, Y = 12.0f } }, // Gazelle Hawk
		{ 05679, new PositionInfo { X = 25.0f, Y = 15.0f } }, // Gelid Bhoot
		{ 05686, new PositionInfo { X = 10.0f, Y = 27.0f } }, // Goosefish
		{ 05671, new PositionInfo { X = 11.0f, Y = 11.0f } }, // Leshy
		{ 05687, new PositionInfo { X = 11.0f, Y = 17.0f } }, // Mossling
		{ 05683, new PositionInfo { X = 12.0f, Y = 17.0f } }, // Mountain Grizzly
		{ 05691, new PositionInfo { X = 35.0f, Y = 25.0f } }, // Qalyana Brahmin
		{ 05689, new PositionInfo { X = 35.0f, Y = 25.0f } }, // Qalyana Kshatriya
		{ 05690, new PositionInfo { X = 35.0f, Y = 25.0f } }, // Qalyana Shudra
		{ 05688, new PositionInfo { X = 35.0f, Y = 25.0f } }, // Sacred Marid
		{ 05675, new PositionInfo { X = 10.0f, Y = 12.0f } }, // Sapria
		{ 05677, new PositionInfo { X = 22.0f, Y = 11.0f } }, // Spinner
		{ 05693, new PositionInfo { X = 29.0f, Y = 24.0f } }, // Teleoceras
		{ 05678, new PositionInfo { X = 28.0f, Y = 15.0f } }, // Velodyna Pugil
		{ 05680, new PositionInfo { X = 17.0f, Y = 10.0f } }, // Velodyna Sarcosuchus

		// The Peaks
		{ 05705, new PositionInfo { X = 25.0f, Y = 11.0f } }, // Crag Claw
		{ 05701, new PositionInfo { X = 18.7f, Y = 12.9f } }, // Bloodglider
		{ 05702, new PositionInfo { X = 14.0f, Y = 08.0f } }, // Fluturini
		{ 05703, new PositionInfo { X = 12.0f, Y = 08.0f } }, // Gyr Abanian Hornbill
		{ 05713, new PositionInfo { X = 25.0f, Y = 33.0f } }, // Highland Eruca
		{ 05712, new PositionInfo { X = 24.0f, Y = 29.0f } }, // Jhammel
		{ 05714, new PositionInfo { X = 15.0f, Y = 27.0f } }, // Kongamato
		{ 05707, new PositionInfo { X = 34.0f, Y = 09.0f } }, // Marble Urolith
		{ 05715, new PositionInfo { X = 09.0f, Y = 26.0f } }, // Pantera
		{ 05708, new PositionInfo { X = 24.0f, Y = 14.0f } }, // Scarab Beetle
		{ 05711, new PositionInfo { X = 24.0f, Y = 24.0f } }, // True Griffin

		// The Ruby Sea
		{ 05737, new PositionInfo { X = 31.0f, Y = 35.0f } }, // Bombfish
		{ 05736, new PositionInfo { X = 34.0f, Y = 05.0f } }, // Coralshell
		{ 05740, new PositionInfo { X = 26.0f, Y = 30.0f } }, // Flying Shark
		{ 05742, new PositionInfo { X = 23.0f, Y = 33.0f } }, // Gasame
		{ 05734, new PositionInfo { X = 14.0f, Y = 10.0f } }, // Gyuki
		{ 05751, new PositionInfo { X = 25.0f, Y = 25.0f } }, // Naked Yumemi
		{ 05743, new PositionInfo { X = 07.0f, Y = 30.0f } }, // Red Bukan
		{ 05745, new PositionInfo { X = 08.0f, Y = 28.0f } }, // Red Honkan
		{ 05744, new PositionInfo { X = 09.5f, Y = 25.2f } }, // Red Hyoe
		{ 05738, new PositionInfo { X = 33.0f, Y = 11.0f } }, // Sea Serpent
		{ 05739, new PositionInfo { X = 26.0f, Y = 06.0f } }, // Shiranui
		{ 05746, new PositionInfo { X = 07.0f, Y = 27.0f } }, // Striped Ray
		{ 05733, new PositionInfo { X = 29.0f, Y = 37.0f } }, // Tatsunoko
		{ 05735, new PositionInfo { X = 35.0f, Y = 21.0f } }, // Unkiu
		{ 05750, new PositionInfo { X = 25.0f, Y = 25.0f } }, // Yumemi

		// Yanxia
		{ 05761, new PositionInfo { X = 18.0f, Y = 31.0f } }, // Bi Fang
		{ 05769, new PositionInfo { X = 28.0f, Y = 08.0f } }, // Ebisu Catfish
		{ 05752, new PositionInfo { X = 27.0f, Y = 34.0f } }, // Lupin Bladehand
		{ 05754, new PositionInfo { X = 24.0f, Y = 32.0f } }, // Lupin Bowhand
		{ 05753, new PositionInfo { X = 23.0f, Y = 28.0f } }, // Lupin Spearhand
		{ 05768, new PositionInfo { X = 19.0f, Y = 11.0f } }, // Magatsu Kiyofusa
		{ 05763, new PositionInfo { X = 33.0f, Y = 17.0f } }, // Minobi
		{ 05757, new PositionInfo { X = 30.0f, Y = 23.0f } }, // Rhino Beetle
		{ 05765, new PositionInfo { X = 30.0f, Y = 34.0f } }, // Taoquan
		{ 05755, new PositionInfo { X = 24.0f, Y = 32.0f } }, // Tenaga
		{ 05764, new PositionInfo { X = 23.0f, Y = 30.0f } }, // Vanara
		{ 05762, new PositionInfo { X = 25.0f, Y = 26.0f } }, // Water Serpent

		// The Azim Steppe
		{ 05785, new PositionInfo { X = 15.0f, Y = 19.0f } }, // Baras
		{ 05788, new PositionInfo { X = 17.0f, Y = 26.0f } }, // Chaochu
		{ 05777, new PositionInfo { X = 23.0f, Y = 15.0f } }, // Halgai
		{ 05778, new PositionInfo { X = 16.0f, Y = 11.0f } }, // Khun Chuluu
		{ 05781, new PositionInfo { X = 31.0f, Y = 17.0f } }, // Mammoth
		{ 05783, new PositionInfo { X = 12.0f, Y = 29.0f } }, // Manzasiri
		{ 05775, new PositionInfo { X = 28.0f, Y = 13.0f } }, // Matamata
		{ 05782, new PositionInfo { X = 09.0f, Y = 21.0f } }, // Matanga
		{ 05779, new PositionInfo { X = 23.0f, Y = 10.0f } }, // Muu Shuwuu
		{ 05780, new PositionInfo { X = 34.0f, Y = 18.0f } }, // Purbol
		{ 05776, new PositionInfo { X = 26.0f, Y = 29.0f } }, // Steppe Dhole
		{ 05773, new PositionInfo { X = 31.0f, Y = 32.0f } }, // Steppe Dzo

		// The Lochs
		{ 05723, new PositionInfo { X = 18.0f, Y = 32.0f } }, // Abaddon
		{ 05725, new PositionInfo { X = 26.0f, Y = 11.0f } }, // Abalathian Minotaur
		{ 05720, new PositionInfo { X = 25.0f, Y = 18.0f } }, // Chelone
		{ 05727, new PositionInfo { X = 29.0f, Y = 15.0f } }, // Creeping Edila
		{ 05729, new PositionInfo { X = 05.7f, Y = 26.7f } }, // Dark Clay Beast
		{ 05732, new PositionInfo { X = 23.0f, Y = 10.0f } }, // Guard Bhoot
		{ 05716, new PositionInfo { X = 08.0f, Y = 17.0f } }, // Kaluk
		{ 05724, new PositionInfo { X = 16.0f, Y = 12.0f } }, // Loch Leech
		{ 05730, new PositionInfo { X = 17.0f, Y = 16.0f } }, // Loch Nanka
		{ 05717, new PositionInfo { X = 20.0f, Y = 18.0f } }, // Phoebad
		{ 05721, new PositionInfo { X = 16.0f, Y = 21.0f } }, // Soblyn
		{ 05722, new PositionInfo { X = 22.0f, Y = 23.0f } }, // Salt Dhruva
		{ 05728, new PositionInfo { X = 17.0f, Y = 08.0f } }, // Specter
		{ 05726, new PositionInfo { X = 25.0f, Y = 29.0f } }, // Vepar
		{ 05719, new PositionInfo { X = 20.0f, Y = 25.0f } }, // Yabby

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
		{ 08550, new PositionInfo { X = 29.4f, Y = 25.4f } }, // Ancient Lizard
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

		// Dawntrail
		// Urqopacha
		{ 13079, new PositionInfo { X = 32.0f, Y = 13.4f } }, // Alpaca
		{ 13090, new PositionInfo { X = 22.5f, Y = 16.9f } }, // Bandercoeurl
		{ 13083, new PositionInfo { X = 22.5f, Y = 11.8f } }, // Barbmole
		{ 13081, new PositionInfo { X = 33.5f, Y = 34.2f } }, // Bloodsucker
		{ 13087, new PositionInfo { X = 28.7f, Y = 09.1f } }, // Chaba Gedan
		{ 13084, new PositionInfo { X = 22.4f, Y = 33.9f } }, // Chirwagur Sabreur
		{ 13085, new PositionInfo { X = 16.6f, Y = 28.0f } }, // Flint
		{ 13094, new PositionInfo { X = 15.9f, Y = 23.7f } }, // Huallepen
		{ 13096, new PositionInfo { X = 25.3f, Y = 22.2f } }, // Longjaw
		{ 13080, new PositionInfo { X = 19.5f, Y = 14.8f } }, // Megamaguey
		{ 13095, new PositionInfo { X = 35.0f, Y = 27.5f } }, // Molten Phoebad
		{ 13091, new PositionInfo { X = 19.3f, Y = 17.1f } }, // Mountain Bear
		{ 13093, new PositionInfo { X = 24.2f, Y = 27.3f } }, // Naryordor
		{ 13092, new PositionInfo { X = 15.2f, Y = 13.3f } }, // Notocactuar
		{ 13097, new PositionInfo { X = 09.4f, Y = 22.9f } }, // Ridgetrap
		{ 13088, new PositionInfo { X = 25.7f, Y = 17.0f } }, // Siehnam
		{ 13082, new PositionInfo { X = 25.9f, Y = 14.0f } }, // Silver Lobo
		{ 13086, new PositionInfo { X = 31.9f, Y = 18.5f } }, // Tulichu
		{ 13098, new PositionInfo { X = 28.1f, Y = 28.4f } }, // Tulidile
		{ 13089, new PositionInfo { X = 30.8f, Y = 15.4f } }, // Turali Ratel

		// Kozama'uka
		{ 12946, new PositionInfo { X = 19.5f, Y = 23.8f } }, // Bird of Ligaka
		{ 12935, new PositionInfo { X = 14.0f, Y = 19.3f } }, // Glowfly
		{ 12930, new PositionInfo { X = 10.2f, Y = 09.5f } }, // Hammerhead Crocodile
		{ 12936, new PositionInfo { X = 21.1f, Y = 12.7f } }, // Heavy Matamata
		{ 12952, new PositionInfo { X = 13.2f, Y = 29.6f } }, // Jungle Iguana
		{ 12934, new PositionInfo { X = 14.2f, Y = 16.3f } }, // Jungle Orobon
		{ 12938, new PositionInfo { X = 13.8f, Y = 11.2f } }, // Jungle Pelican
		{ 12943, new PositionInfo { X = 11.2f, Y = 22.8f } }, // Lesser Apollyon
		{ 12941, new PositionInfo { X = 33.0f, Y = 14.6f } }, // Ocelot
		{ 12949, new PositionInfo { X = 36.9f, Y = 34.9f } }, // Paper Wasp
		{ 12939, new PositionInfo { X = 29.9f, Y = 15.5f } }, // Poison Frog
		{ 12933, new PositionInfo { X = 15.7f, Y = 14.4f } }, // Rhino Beetle
		{ 12937, new PositionInfo { X = 26.8f, Y = 12.3f } }, // Stinkshell
		{ 12944, new PositionInfo { X = 19.9f, Y = 28.4f } }, // Swampmonk
		{ 12948, new PositionInfo { X = 34.2f, Y = 27.5f } }, // Tegu
		{ 12947, new PositionInfo { X = 08.0f, Y = 32.5f } }, // Tomaton
		{ 12932, new PositionInfo { X = 20.7f, Y = 15.8f } }, // Toucalibri
		{ 12950, new PositionInfo { X = 17.9f, Y = 32.2f } }, // Turali Morbol
		{ 12951, new PositionInfo { X = 08.7f, Y = 26.7f } }, // Turali Netzach
		{ 12942, new PositionInfo { X = 31.5f, Y = 19.5f } }, // U'out
		{ 12931, new PositionInfo { X = 14.8f, Y = 05.5f } }, // Uolon
		{ 12945, new PositionInfo { X = 28.9f, Y = 25.3f } }, // Widowmaker
		{ 12940, new PositionInfo { X = 33.6f, Y = 08.5f } }, // Woodsman

		// Yak T'el
		{ 12957, new PositionInfo { X = 21.1f, Y = 05.6f } }, // Balyaborr
		{ 12966, new PositionInfo { X = 07.4f, Y = 24.4f } }, // Blue Leafkin
		{ 12969, new PositionInfo { X = 16.4f, Y = 28.9f } }, // Blue Morpho
		{ 12964, new PositionInfo { X = 17.8f, Y = 24.4f } }, // Branchbearer
		{ 12971, new PositionInfo { X = 16.3f, Y = 37.7f } }, // Fly Agaric
		{ 12970, new PositionInfo { X = 20.4f, Y = 18.1f } }, // Ja Tiika Moth
		{ 12958, new PositionInfo { X = 24.3f, Y = 06.3f } }, // Killer Piranha
		{ 12955, new PositionInfo { X = 09.5f, Y = 20.4f } }, // Leaf Mantis
		{ 12965, new PositionInfo { X = 30.2f, Y = 28.3f } }, // Mourner
		{ 12954, new PositionInfo { X = 17.0f, Y = 13.8f } }, // Necrosis 
		{ 12962, new PositionInfo { X = 35.3f, Y = 23.1f } }, // Pitcher Weed
		{ 12967, new PositionInfo { X = 30.6f, Y = 35.7f } }, // Sarracenia
		{ 12960, new PositionInfo { X = 28.0f, Y = 18.4f } }, // T'ohsoq
		{ 12961, new PositionInfo { X = 32.8f, Y = 20.5f } }, // T'ohts'on
		{ 12953, new PositionInfo { X = 24.0f, Y = 11.8f } }, // Ty'aitya
		{ 12956, new PositionInfo { X = 12.4f, Y = 09.9f } }, // Vawtsaral Br'aax
		{ 12959, new PositionInfo { X = 32.2f, Y = 12.7f } }, // Yak T'el Squib

		// Shaaloani
		{ 12990, new PositionInfo { X = 14.7f, Y = 09.4f } }, // Aspis
		{ 12989, new PositionInfo { X = 27.6f, Y = 13.1f } }, // Ceratoraptor
		{ 12975, new PositionInfo { X = 11.4f, Y = 17.1f } }, // Cerule Anala
		{ 12977, new PositionInfo { X = 19.9f, Y = 21.5f } }, // Cerule Bomb
		{ 12992, new PositionInfo { X = 31.8f, Y = 23.8f } }, // Flying Popoto
		{ 12996, new PositionInfo { X = 28.8f, Y = 23.5f } }, // Grasslands Worm
		{ 12995, new PositionInfo { X = 24.4f, Y = 15.6f } }, // Gritclaw
		{ 12997, new PositionInfo { X = 12.3f, Y = 12.9f } }, // Horned Lizard
		{ 12988, new PositionInfo { X = 21.4f, Y = 31.8f } }, // Lunyucaua'pya
		{ 12987, new PositionInfo { X = 18.0f, Y = 31.6f } }, // Lunyuhiyshahe
		{ 12991, new PositionInfo { X = 24.3f, Y = 11.3f } }, // Rroneek
		{ 12976, new PositionInfo { X = 25.9f, Y = 29.0f } }, // Sunbeard
		{ 12993, new PositionInfo { X = 35.1f, Y = 11.1f } }, // Toari Alligator
		{ 12972, new PositionInfo { X = 30.3f, Y = 33.1f } }, // Tumbleclaw
		{ 12994, new PositionInfo { X = 29.2f, Y = 07.9f } }, // Turali Hawksbill
		{ 12978, new PositionInfo { X = 14.1f, Y = 23.3f } }, // Wild Dhara
		{ 12986, new PositionInfo { X = 12.7f, Y = 30.2f } }, // Yeheheceyaa

		// Heritage Found
		{ 13115, new PositionInfo { X = 09.6f, Y = 19.5f } }, // Asterodia
		{ 13101, new PositionInfo { X = 33.4f, Y = 27.7f } }, // Axe Beak
		{ 13103, new PositionInfo { X = 22.5f, Y = 16.7f } }, // Bolt Hound
		{ 13116, new PositionInfo { X = 28.2f, Y = 26.7f } }, // Cauahealoa
		{ 13117, new PositionInfo { X = 32.6f, Y = 22.7f } }, // Cauahepya
		{ 13108, new PositionInfo { X = 15.8f, Y = 22.2f } }, // Defective Aerostat
		{ 13107, new PositionInfo { X = 15.8f, Y = 22.2f } }, // Defective Sentry R8
		{ 13106, new PositionInfo { X = 10.6f, Y = 26.2f } }, // Defective Sentry S8
		{ 13109, new PositionInfo { X = 11.3f, Y = 11.5f } }, // Defective Turret
		{ 13105, new PositionInfo { X = 21.3f, Y = 27.6f } }, // Eyeclops
		{ 13104, new PositionInfo { X = 14.8f, Y = 17.2f } }, // Gomphotherium
		{ 13113, new PositionInfo { X = 35.2f, Y = 14.2f } }, // Katoblepas
		{ 13112, new PositionInfo { X = 24.3f, Y = 20.9f } }, // Myrmeleon
		{ 13114, new PositionInfo { X = 11.2f, Y = 33.2f } }, // Python
		{ 13111, new PositionInfo { X = 30.8f, Y = 13.9f } }, // Thunder Spirit
		{ 13110, new PositionInfo { X = 15.6f, Y = 32.4f } }, // Woolback
		{ 13102, new PositionInfo { X = 24.8f, Y = 07.3f } }, // Yyenisheyni Bat

		// Living Memory
		{ 13121, new PositionInfo { X = 33.1f, Y = 34.4f } }, // Acrocat
		{ 13137, new PositionInfo { X = 12.0f, Y = 18.7f } }, // Agavoides
		{ 13133, new PositionInfo { X = 30.5f, Y = 17.1f } }, // Alexandrian Clipper
		{ 13130, new PositionInfo { X = 26.9f, Y = 17.6f } }, // Blazing Soul
		{ 13127, new PositionInfo { X = 35.9f, Y = 27.2f } }, // Brownie
		{ 13136, new PositionInfo { X = 17.8f, Y = 21.9f } }, // Everlasting Yew
		{ 13124, new PositionInfo { X = 09.9f, Y = 36.2f } }, // Fluid Soul
		{ 13131, new PositionInfo { X = 36.5f, Y = 18.3f } }, // Gargantua
		{ 13120, new PositionInfo { X = 32.3f, Y = 27.1f } }, // Gemkeeper
		{ 13129, new PositionInfo { X = 26.6f, Y = 08.7f } }, // Matchlock Scorpion
		{ 13118, new PositionInfo { X = 33.2f, Y = 16.3f } }, // Outrunner
		{ 13132, new PositionInfo { X = 30.3f, Y = 12.5f } }, // Pineapple
		{ 13125, new PositionInfo { X = 13.0f, Y = 34.5f } }, // Remembird
		{ 13119, new PositionInfo { X = 28.4f, Y = 31.6f } }, // Seeker Bat
		{ 13139, new PositionInfo { X = 18.0f, Y = 15.2f } }, // Timberman
		{ 13122, new PositionInfo { X = 17.7f, Y = 30.5f } }, // Torbalan
		{ 13138, new PositionInfo { X = 11.8f, Y = 12.9f } }, // Walking Tree
	};

	public enum OpenType {
		None, // Just place marker
		ShowOpen, // Show special map with radius
		MarkerOpen // Show normal map
	}

	public static unsafe void CreateMapMarker(uint territoryType, uint mapId, uint mobHuntId, string? mobHuntName,
		OpenType openType = OpenType.MarkerOpen) {
		AgentMap* map = AgentMap.Instance();

		if (map == null) {
			return;
		}

		(int X, int Y) pos = MapToWorldCoordinates(Database[mobHuntId].Coordinate, mapId);

		map->IsFlagMarkerSet = 0;
		map->SetFlagMapMarker(territoryType, mapId, pos.X, pos.Y, 60004);

		switch (openType) {
			case OpenType.None:
				break;
			case OpenType.ShowOpen:
				map->AgentInterface.Hide();
				map->AddGatheringTempMarker(pos.X, pos.Y, 150, 60004, 4, mobHuntName);
				map->OpenMap(mapId, territoryType, mobHuntName, MapType.GatheringLog);
				break;
			case OpenType.MarkerOpen:
				map->AgentInterface.Hide();
				map->OpenMap(mapId, territoryType);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(openType), openType, null);
		}
	}

	private static (int X, int Y) MapToWorldCoordinates(Vector2 pos, uint mapId) {
		ushort scale = Service.DataManager.GetExcelSheet<Map>()?.GetRow(mapId)?.SizeFactor ?? 100;
		float num = scale / 100f;
		float x = (float)(((pos.X - 1.0) * num / 41.0 * 2048.0) - 1024.0) / num * 1000f;
		float y = (float)(((pos.Y - 1.0) * num / 41.0 * 2048.0) - 1024.0) / num * 1000f;
		x = (int)(MathF.Round(x, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f / 1000f;
		y = (int)(MathF.Round(y, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f / 1000f;
		return ((int)x, (int)y);
	}

	private static Vector2 ConvertPixelPositionToMapCoordinate(int x, int y, float scale) {
		float num = scale / 100f;
		return new Vector2(
			ConvertRawPositionToMapCoordinate((int)((x - 1024) * num * 1000f), scale),
			ConvertRawPositionToMapCoordinate((int)((y - 1024) * num * 1000f), scale));
	}

	private static float ConvertRawPositionToMapCoordinate(int pos, float scale) {
		float num1 = scale / 100f;
		float num2 = (float)(pos * (double)num1 / 1000.0f);
		return (40.96f / num1 * ((num2 + 1024.0f) / 2048.0f)) + 1.0f;
	}

	public static void TeleportToNearestAetheryte(uint territoryType, uint mapId, uint mobHuntId) {
		Map? mapRow = Service.DataManager.Excel.GetSheet<Map>()?.GetRow(mapId);

		if (mapRow == null) {
			return;
		}

		ushort? nearestAetheryteId = Service.DataManager.Excel.GetSheet<MapMarker>()
			?.Where(x => x.DataType == 3 && x.RowId == mapRow.MapMarkerRange)
			.Select(
				x => new {
					distance = Vector2.DistanceSquared(
						Database[mobHuntId].Coordinate,
						ConvertPixelPositionToMapCoordinate(x.X, x.Y, mapRow.SizeFactor)),
					rowId = x.DataKey
				})
			.OrderBy(x => x.distance)
			.FirstOrDefault()?.rowId;

		Aetheryte? nearestAetheryte =
			territoryType == 399 // Support the unique case of aetheryte not being in the same map
				? mapRow.TerritoryType?.Value?.Aetheryte.Value
				: Service.DataManager.Excel.GetSheet<Aetheryte>()?.FirstOrDefault(
					x =>
						x.IsAetheryte && x.Territory.Row == territoryType && x.RowId == nearestAetheryteId);

		if (nearestAetheryte == null) {
			return;
		}

		Plugin.TeleportConsumer?.Teleport(nearestAetheryte.RowId);
	}
}
