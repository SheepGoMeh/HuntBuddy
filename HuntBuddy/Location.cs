using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Lumina.Excel.GeneratedSheets;
using static HuntBuddy.Location;
using MapType = FFXIVClientStructs.FFXIV.Client.UI.Agent.MapType;

namespace HuntBuddy
{
	public static class Location
	{
		public class PositionInfo
		{
			public float X { get; init; }

			public float Y { get; init; }

			public int Radius { get; init; }

			public uint Fate { get; init; }

			public Vector2 Coordinate => new (this.X, this.Y);
		}

		// MobHuntId as key
		public static readonly Dictionary<uint, List<PositionInfo>> Database = new()
		{
			// ARR
			// B Rank
			// Middle La Noscea
			{ 02928 , new List<PositionInfo>() {						// Skogs Fru
                new PositionInfo { X = 24.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 8.0f,  Radius = 50 },
			} },
			// Lower La Noscea
			{ 02929, new List<PositionInfo>() {							// Barbastelle
				new PositionInfo { X = 23.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 37.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 38.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 17.0f, Radius = 50 },
			} },
			// Western La Noscea
			{ 02931, new List<PositionInfo>() {							// Dark Helmet
                new PositionInfo { X = 16.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 15.0f, Radius = 50 },
			} },
			// Eastern La Noscea
			{ 02930 , new List<PositionInfo>() {						// Bloody Mary
                new PositionInfo { X = 22.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 36.0f, Radius = 50 },
			} },
			// Upper La Noscea
			{ 02932 , new List<PositionInfo>() {						// Myradrosh
                new PositionInfo { X = 29.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 22.0f, Radius = 50 },
			} },
			// Outer La Noscea
			{ 02933, new List<PositionInfo>() {							// Vuokho
                new PositionInfo { X = 16.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 9.0f,  Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 8.0f,  Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 7.0f,  Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 7.0f,  Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 8.0f,  Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 6.0f,  Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 7.0f,  Radius = 50 },
			} },
			// Central Thanalan
			{ 02924, new List<PositionInfo>() {							// Ovjang
				new PositionInfo { X = 23.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 21.0f, Radius = 50 },
			} },
			// Western Thanalan
			{ 02923, new List<PositionInfo>() {							// Sewer Syrup
				new PositionInfo { X = 26.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 8.0f,  Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 6.0f,  Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 7.0f,  Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 6.0f,  Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 7.0f,  Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 5.0f,  Radius = 50 },
				new PositionInfo { X = 08.0f, Y = 5.0f,  Radius = 50 },
			} },
			// Eastern Thanalan
			{ 02925, new List<PositionInfo>() {							// Gatling
				new PositionInfo { X = 13.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 18.0f, Radius = 50 },
			} },
			// Southern Thanalan
			{ 02926, new List<PositionInfo>() {							// Albin the Ashen
				new PositionInfo { X = 18.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 38.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 38.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 38.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 40.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 9.0f,  Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 8.0f,  Radius = 50 },
			} },
			// Northern Thanalan
			{ 02927, new List<PositionInfo>() {							// Flame Sergeant Dalvag
				new PositionInfo { X = 21.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 14.0f, Radius = 50 },
			} },
			// Central Shroud
			{ 02919, new List<PositionInfo>() {							// White Joker
				new PositionInfo { X = 22.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 23.0f, Radius = 50 },
			} },
			// South Shroud
			{ 02921, new List<PositionInfo>() {							// Monarch Ogrefly
				new PositionInfo { X = 17.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 24.0f, Radius = 50 },
			} },
			// Eastern Shroud
			{ 02920, new List<PositionInfo>() {							// Stinging Sophie
				new PositionInfo { X = 25.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 29.0f, Radius = 50 },
			} },
			// North Shroud
			{ 02922, new List<PositionInfo>() {							// Phecda
				new PositionInfo { X = 21.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 20.0f, Radius = 50 },
			} },
			// Coerthas Central Highlands
			{ 02934, new List<PositionInfo>() {							// Naul
				new PositionInfo { X = 24.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 09.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 06.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 09.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 09.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 09.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 09.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 06.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 05.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 04.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 06.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 9.0f,  Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 8.0f,  Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 8.0f,  Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 7.0f,  Radius = 50 },
			} },
			// Mor Dhona
			{ 02935, new List<PositionInfo>() {							// Leech King
				new PositionInfo { X = 19.0f, Y = 08.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 09.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 09.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 08.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 06.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 06.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 07.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 09.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 14.0f, Radius = 50 },
			} },

			// Daily Targets
			// Middle La Noscea
			{ 00849, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 17.0f, Radius = 50, Fate = 220 } } },	// Menuis
			{ 00851, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y =  9.0f, Radius = 50, Fate = 238 } } },	// Chupacabra
			// Lower La Noscea
			{ 01357, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 37.0f, Radius = 50, Fate = 245 } } },	// Mandragora Prince
			{ 00857, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 33.0f, Radius = 50, Fate = 333 } } },	// Padfoot
			{ 00852, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 25.0f, Radius = 50, Fate = 257 } } },	// Cuachac
			{ 00856, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 13.0f, Radius = 50, Fate = 265 } } },	// 426th Order Pickman Bu Ga
			// Eastern La Noscea
			{ 00411, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 21.0f, Radius = 150 } } },			// Grass Raptor
			{ 01822, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 20.0f, Radius = 150 } } },			// 2nd Cohort Laquearius
			{ 01823, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 20.0f, Radius = 150 } } },			// 2nd Cohort Eques
			{ 01825, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 20.0f, Radius = 150 } } },			// 2nd Cohort Signifer
			{ 01826, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 20.0f, Radius = 150 } } },			// 2nd Cohort Vanguard
			{ 00639, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 25.0f, Radius = 150 } } },			// Colibri
			{ 00361, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 26.0f, Radius = 150 } } },			// Bloodshore Bell
			{ 00373, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 25.0f, Radius = 150 } } },			// Kobold Missionary
			{ 00369, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 25.0f, Radius = 150 } } },			// Kobold Pitman
			{ 00858, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 32.0f, Radius = 50, Fate = 280 } } },	// Kokoroon Quickfingers
			{ 00351, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 32.0f, Radius = 150 } } },			// Qiqirn Gullroaster
			{ 00341, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 35.0f, Radius = 150 } } },			// Apkallu
			{ 00560, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 35.0f, Radius = 150 } } },			// Snipper
			{ 01313, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 32.0f, Radius = 150 } } },			// Large Buffalo
			{ 00353, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 33.0f, Radius = 150 } } },			// Goobbue
			{ 01516, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 31.0f, Radius = 50, Fate = 563 } } },	// Jolly Green 
			{ 00352, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 28.0f, Radius = 150 } } },			// Jungle Coeurl
			{ 01515, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 28.0f, Radius = 50, Fate = 561 } } },	// Sekhmet
			{ 00026, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 26.0f, Radius = 150 } } },			// Gigantoad
			{ 01517, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 25.0f, Radius = 50, Fate = 564 } } },	// Metshaldjas
			// Western La Noscea
			{ 00862, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 22.0f, Radius = 50, Fate = 309 } } },	// Tryptix Stumblemox
			{ 00565, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 19.0f, Radius = 150 } } },			// Trenchtooth Sahagin
			{ 00386, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 18.0f, Radius = 150 } } },			// Shelfscale Sahagin
			{ 01518, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 18.0f, Radius = 50, Fate = 572 } } },	// Voll The Sharkskinned
			{ 00384, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 19.0f, Radius = 150 } } },			// Shelfclaw Sahagin
			{ 00389, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 22.0f, Radius = 150 } } },			// Shelfspine Sahagin
			{ 00360, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 17.0f, Radius = 150 } } },			// Sea Wasp
			{ 00343, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 16.0f, Radius = 50, Fate = 575 } } },	// Aermswys The Stained
			{ 00559, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 17.0f, Radius = 150 } } },			// Shelfeye Reaver
			{ 02356, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 14.0f, Radius = 50, Fate = 578 } } },	// Yarr The Wavefiend
			{ 01828, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 13.0f, Radius = 150 } } },			// Sapsa Shelfclaw
			{ 01830, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 13.0f, Radius = 150 } } },			// Sapsa Shelftooth
			{ 01829, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 14.0f, Radius = 150 } } },			// Sapsa Shelfspine
			{ 01529, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 34.0f, Radius = 50, Fate = 577 } } },	// Mantis King
			{ 01852, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 35.0f, Radius = 150 } } },			// Preying Mantis
			{ 01853, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 36.0f, Radius = 150 } } },			// Lammergeyer
			{ 00861, new List<PositionInfo>() { new PositionInfo { X = 36.0f, Y = 28.0f, Radius = 50, Fate = 306 } } },	// Barometz
			{ 00859, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 28.0f, Radius = 50, Fate = 290 } } },	// Gluttonous Gertrude
			{ 00860, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 29.0f, Radius = 50, Fate = 295 } } },	// Old Six-Arms
			// Upper La Noscea
			{ 00413, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 24.0f, Radius = 150 } } },			// Mamool Ja Executioner
			{ 00414, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 25.0f, Radius = 150 } } },			// Mamool Ja Breeder
			{ 01519, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 24.0f, Radius = 50, Fate = 322 } } },	// Oannes
			{ 01521, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 24.0f, Radius = 50, Fate = 329 } } },	// Zoredonite
			{ 01522, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 23.0f, Radius = 50, Fate = 331 } } },	// Scarface Bugaal Ja
			{ 00643, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 22.0f, Radius = 150 } } },			// Uragnite
			{ 00391, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 22.0f, Radius = 150 } } },			// Salamander
			{ 00376, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 19.0f, Radius = 150 } } },			// Kobold Sidesman
			{ 01520, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 24.0f, Radius = 50, Fate = 323 } } },	// Karkinos
			{ 00886, new List<PositionInfo>() { new PositionInfo { X =  8.0f, Y = 21.0f, Radius = 50, Fate = 314 } } },	// Simurgh
			// Outer La Noscea
			{ 00412, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 15.0f, Radius = 150 } } },			// Velociraptor
			{ 00562, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 15.0f, Radius = 150 } } },			// Kobold Quarryman
			{ 00270, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 14.0f, Radius = 150 } } },			// Grenade
			{ 00377, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 15.0f, Radius = 150 } } },			// Kobold Roundsman
			{ 00375, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 12.0f, Radius = 150 } } },			// Kobold Bedesman
			{ 01524, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 11.0f, Radius = 50, Fate = 586 } } },	// 59th Order Pickman Be Ze
			{ 00371, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 12.0f, Radius = 150 } } },			// Kobold Priest
			{ 01832, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y =  9.0f, Radius = 150 } } },			// U'Ghamaro Roundsman
			{ 02357, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y =  8.0f, Radius = 50, Fate = 599 } } },	// 5th Order Patriarch Ze Bu
			{ 01834, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y =  7.0f, Radius = 150 } } },			// U'Ghamaro Bedesman
			{ 02516, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y =  6.0f, Radius = 50, Fate = 700 } } },	// 59th Order Roundsman Ge Ga
			{ 01835, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y =  6.0f, Radius = 150 } } },			// U'Ghamaro Priest
			{ 01833, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y =  6.0f, Radius = 150 } } },			// U'Ghamaro Quarryman
			{ 01670, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y =  6.0f, Radius = 50, Fate = 597 } } },	// 59th Order Bedesman Bi Go
			{ 01836, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y =  9.0f, Radius = 150 } } },			// Synthetic Doblyn
			{ 00407, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 12.5f, Radius = 150 } } },			// Ringtail
			{ 00106, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 11.0f, Radius = 150 } } },			// Coeurl
			{ 01527, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 15.0f, Radius = 50, Fate = 594 } } },	// Number 128
			{ 01523, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 15.0f, Radius = 50, Fate = 581 } } },	// Ose
			{ 01526, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 18.0f, Radius = 50, Fate = 591 } } },	// Peryton
			{ 01525, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 18.0f, Radius = 50, Fate = 589 } } },	// Brounger
			{ 00046, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 18.0f, Radius = 150 } } },			// Plasmoid

			// Central Shroud
			{ 00445, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 24.0f, Radius = 50, Fate = 123 } } },	// Stagnant Water Sprite
			{ 00512, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 25.0f, Radius = 50, Fate = 128 } } },	// Alux
			{ 00447, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 30.0f, Radius = 50, Fate = 137 } } },	// Matagaigai
			{ 00448, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 25.0f, Radius = 50, Fate = 142 } } },	// Lou Carcolh
			{ 01329, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 22.0f, Radius = 50, Fate = 209 } } },	// Jaded Jody
			{ 00238, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 21.0f, Radius = 150 } } },			// Stroper
			{ 00236, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 19.0f, Radius = 150 } } },			// Revenant
			{ 01661, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 18.0f, Radius = 50, Fate = 604 } } },	// Spiteful
			{ 00131, new List<PositionInfo>() { new PositionInfo { X =  9.0f, Y = 18.0f, Radius = 150 } } },			// Crater Golem
			{ 00091, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 16.0f, Radius = 150 } } },			// Spriggan
			{ 00130, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 18.0f, Radius = 150 } } },			// Lindwurm
			{ 00446, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 22.0f, Radius = 50, Fate = 125 } } },	// Asipatra
			{ 00055, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 22.0f, Radius = 150 } } },			// Deathgaze
			{ 00207, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 23.0f, Radius = 150 } } },			// Floating Eye
			{ 00051, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 21.0f, Radius = 50, Fate = 126 } } }, // Alpha Anole
			// East Shroud
			{ 00513, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 27.0f, Radius = 50, Fate = 144 } } },	// Prince Of Pestilence
			{ 00449, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 29.0f, Radius = 50, Fate = 150 } } },	// Jackanapes
			{ 00222, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 24.0f, Radius = 150 } } },			// Molted Ziz
			{ 02350, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 21.0f, Radius = 50, Fate = 691 } } },	// Proto Armor
			{ 00058, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 20.0f, Radius = 150 } } },			// 3rd Cohort Laquearius
			{ 00066, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 20.0f, Radius = 150 } } },			// Sylvan Snarl
			{ 00164, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 17.0f, Radius = 150 } } },			// Dreamtoad
			{ 00567, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 17.0f, Radius = 150 } } },			// Sylphlands Condor
			{ 00068, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 16.0f, Radius = 150 } } },			// Sylpheed Sigh
			{ 00069, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 16.0f, Radius = 150 } } },			// Sylpheed Snarl
			{ 01665, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 13.0f, Radius = 50, Fate = 619 } } },	// Volxia Of The Blade
			{ 00067, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 11.0f, Radius = 150 } } },			// Sylpheed Screech
			{ 01664, new List<PositionInfo>() { new PositionInfo { X = 32.4f, Y = 14.4f, Radius = 50, Fate = 616 } } },	// Daxio Of The Dawn
			{ 00053, new List<PositionInfo>() {
				new PositionInfo { X = 32.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 29.1f, Y = 20.9f, Radius = 50 }
			} },																										// 3rd Cohort Hoplomachus
			{ 00061, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 20.0f, Radius = 150 } } },			// 3rd Cohort Signifer
			{ 00233, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 20.0f, Radius = 150 } } },			// Old-Growth Treant
			{ 00065, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 21.0f, Radius = 150 } } },			// Sylvan Sigh
			{ 01662, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 20.0f, Radius = 50, Fate = 609 } } },	// Capricious Cassie
			{ 00237, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 20.0f, Radius = 150 } } },			// Morbol
			{ 00064, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 20.0f, Radius = 150 } } },			// Sylvan Screech
			{ 02367, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 18.0f, Radius = 50, Fate = 692 } } },	// Kafre
			{ 00165, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 16.0f, Radius = 150 } } },			// Milkroot Cluster
			{ 00162, new List<PositionInfo>() { new PositionInfo { X = 23.7f, Y = 14.4f, Radius = 150 } } },			// Milkroot Sapling
			{ 00166, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 13.0f, Radius = 150 } } },			// Sylph Bonnet
			{ 00163, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 10.0f, Radius = 150 } } },			// Sylphlands Sentinel
			{ 01666, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 10.0f, Radius = 50, Fate = 622 } } },	// Pulxio Of The Short Gale
			// South Shroud
			{ 00170, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 21.0f, Radius = 150 } } },			// Deepvoid Deathmouse
			{ 00024, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 22.0f, Radius = 150 } } },			// Treant
			{ 00045, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 24.0f, Radius = 150 } } },			// Will-O'-The-Wisp
			{ 00514, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 22.0f, Radius = 50, Fate = 153 } } },	// Sirocco
			{ 00566, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 25.0f, Radius = 150 } } },			// Midland Condor
			{ 00034, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 29.0f, Radius = 150 } } },			// Adamantoise
			{ 00235, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 30.0f, Radius = 150 } } },			// Bigmouth Orobon
			{ 00451, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 33.0f, Radius = 50, Fate = 169 } } },	// Yabi Two-Tails
			{ 00015, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 25.0f, Radius = 150 } } },			// Wild Hog
			{ 00008, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 23.0f, Radius = 150 } } },			// Ked
			{ 00112, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 25.0f, Radius = 150 } } },			// Lesser Kalong
			{ 01667, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 25.0f, Radius = 50, Fate = 628 } } },	// Phaia
			// North Shroud
			{ 00025, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 25.0f, Radius = 150 } } },			// Dryad
			{ 01669, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 25.0f, Radius = 50, Fate = 634 } } },	// Great Oak
			{ 00516, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 28.0f, Radius = 50, Fate = 178 } } },	// Dschubba
			{ 00452, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 21.0f, Radius = 50, Fate = 185 } } },	// Curupira
			{ 00029, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 21.0f, Radius = 150 } } },			// Dullahan
			{ 01668, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 19.0f, Radius = 50, Fate = 632 } } },	// Daedalus
			{ 00174, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 19.0f, Radius = 150 } } },			// Watchwolf
			{ 00436, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 18.0f, Radius = 150 } } },			// Ixali Windtalon
			{ 00103, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 19.0f, Radius = 150 } } },			// Ixali Boldwing

			// Western Thanalan
			{ 00865, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 21.0f, Radius = 50, Fate = 347 } } },	// Doomed Gigantoad
			{ 00866, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 23.0f, Radius = 50, Fate = 348 } } },	// Cactuar Jack
			{ 00867, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 16.0f, Radius = 50, Fate = 353 } } },	// Bubbly Bernie
			{ 00868, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 10.0f, Radius = 50, Fate = 357 } } },	// Crier Briareos
			{ 00869, new List<PositionInfo>() { new PositionInfo { X = 14.3f, Y =  6.7f, Radius = 50, Fate = 366 } } },	// Daddy Longlegs
			{ 01820, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y =  6.0f, Radius = 150 } } },				// 4th Cohort Vanguard
			{ 01815, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y =  6.0f, Radius = 150 } } },				// 4th Cohort Hoplomachus
			{ 01818, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y =  5.0f, Radius = 150 } } },				// 4th Cohort Secutor
			// Central Thanalan
			{ 00871, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 20.0f, Radius = 50, Fate = 374 } } },	// Guguroon Wetnose
			{ 00874, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 23.0f, Radius = 50, Fate = 389 } } },	// Spitfire
			{ 00872, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 19.0f, Radius = 50, Fate = 376 } } },	// Babaroon Halfshell
			{ 00875, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 14.0f, Radius = 50, Fate = 393 } } },	// Nest Commander
			{ 00873, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 19.0f, Radius = 50, Fate = 385 } } },	// Vodyanoi
			// Eastern Thanalan
			{ 00877, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 17.0f, Radius = 50, Fate = 401 } } },	// Undertaker
			{ 00878, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 21.0f, Radius = 50, Fate = 407 } } },	// Gossamer
			{ 01503, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 24.0f, Radius = 50, Fate = 542 } } },	// Aeetes
			{ 00271, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 25.0f, Radius = 150 } } },			// Golden Fleece
			{ 00634, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 26.0f, Radius = 150 } } },			// Mirrorknight
			{ 00275, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 26.0f, Radius = 150 } } },			// Quartz Doblyn
			{ 01504, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 25.0f, Radius = 50, Fate = 543 } } },	// Bagoly
			// Southern Thanalan
			{ 00885, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 30.0f, Radius = 50, Fate = 455 } } },	// Ulhuadshi
			{ 00290, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 31.0f, Radius = 150 } } },			// Sandworm
			{ 00285, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 32.0f, Radius = 150 } } },			// Russet Yarzon
			{ 00132, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 35.0f, Radius = 150 } } },			// Smoke Bomb
			{ 00324, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 38.0f, Radius = 150 } } },			// Fallen Wizard
			{ 00264, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 36.0f, Radius = 150 } } },			// Sundrake
			{ 02155, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 35.0f, Radius = 150 } } },			// Amalj'aa Halberdier
			{ 00260, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 34.0f, Radius = 150 } } },			// Amalj'aa Divinator
			{ 00884, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 34.0f, Radius = 50, Fate = 436 } } },	// Blackbile Maladd Chah
			{ 00252, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 34.0f, Radius = 150 } } },			// Amalj'aa Sniper
			{ 01506, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 26.0f, Radius = 50, Fate = 430 } } },	// Cindersoot Pegujj Chah
			{ 01838, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 22.0f, Radius = 150 } } },			// Zahar'ak Archer
			{ 00249, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 23.0f, Radius = 150 } } },			// Amalj'aa Archer
			{ 01505, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 20.0f, Radius = 50, Fate = 423 } } },	// Aspidochelone
			{ 01699, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 19.0f, Radius = 50, Fate = 546 } } },	// Bibireze Greysteel
			{ 00339, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 19.0f, Radius = 150 } } },			// Tempered Orator
			{ 00245, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 20.0f, Radius = 150 } } },			// Amalj'aa Lancer
			{ 00257, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 24.0f, Radius = 50, Fate = 427 } } },	// Diamondjaw Nezedd Gah
			{ 00243, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 24.0f, Radius = 150 } } },			// Iron Tortoise
			{ 00253, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 26.0f, Radius = 150 } } },			// Amalj'aa Pugilist
			{ 02354, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 21.0f, Radius = 50, Fate = 558 } } },	// Flamecrest Afajj Koh
			{ 01840, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 18.0f, Radius = 150 } } },			// Zahar'ak Thaumaturge
			{ 01841, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 19.0f, Radius = 150 } } },			// Zahar'ak Battle Drake
			{ 01507, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 19.0f, Radius = 50, Fate = 554 } } },	// Whitespark Hepugg Roh
			{ 01839, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 20.0f, Radius = 150 } } },			// Zahar'ak Pugilist
			{ 00882, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 10.0f, Radius = 50, Fate = 456 } } },	// Gisfrid The Grinder
			// Northern Thanalan
			{ 00242, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 23.0f, Radius = 150 } } },			// Ahriman
			{ 00304, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 23.0f, Radius = 150 } } },			// Basilisk
			{ 01511, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 23.0f, Radius = 50, Fate = 637 } } },	// Bomb Baron
			{ 01508, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 20.0f, Radius = 50, Fate = 446 } } },	// Arimaspi
			{ 01509, new List<PositionInfo>() { new PositionInfo { X = 18.8f, Y = 14.3f, Radius = 50, Fate = 450 } } },	// Vanguard Prototype

			// Coerthas Central Highlands
			{ 00659, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 15.0f, Radius = 150 } } },			// Snow Wolf Pup
			{ 00658, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 14.0f, Radius = 150 } } },			// Vodoriga
			{ 00794, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 11.0f, Radius = 150 } } },			// Redhorn Ogre
			{ 01182, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 15.0f, Radius = 150 } } },			// Taurus
			{ 01842, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 17.0f, Radius = 150 } } },			// Natalan Windtalon
			{ 01845, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 18.0f, Radius = 150 } } },			// Natalan Fogcaller
			{ 02355, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 19.0f, Radius = 50, Fate = 508 } } }, // Kozol Nomotl The Turbulent
			{ 01844, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 20.0f, Radius = 150 } } },			// Natalan Swiftbeak
			{ 01846, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 20.0f, Radius = 150 } } },			// Natalan Watchwolf
			{ 01439, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 23.0f, Radius = 50, Fate = 500 } } },	// Gozol Itzcan The Hatchet
			{ 01843, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 24.0f, Radius = 150 } } },			// Natalan Boldwing
			{ 00662, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 27.0f, Radius = 150 } } },			// Ixali Boundwing
			{ 00660, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 27.0f, Radius = 150 } } },			// Ixali Wildtalon
			{ 01427, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 23.0f, Radius = 50, Fate = 463 } } },	// Downy Dunstan
			{ 00784, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 24.0f, Radius = 150 } } },			// Feral Croc
			{ 01428, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 23.0f, Radius = 50, Fate = 464 } } },	// Gavial
			{ 00114, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 20.0f, Radius = 150 } } },			// Ice Sprite
			{ 01612, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 19.0f, Radius = 150 } } },			// Highland Goobbue
			{ 00795, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 19.0f, Radius = 150 } } },			// Ornery Karakul
			{ 01611, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 17.0f, Radius = 150 } } },			// Snowstorm Goobbue
			{ 01434, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 17.0f, Radius = 50, Fate = 494 } } },	// Roc
			{ 01430, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 20.0f, Radius = 50, Fate = 479 } } },	// Lutin
			{ 01432, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 23.0f, Radius = 50, Fate = 484 } } },	// Rongeur
			{ 01433, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 25.0f, Radius = 50, Fate = 490 } } },	// Klythios
			{ 00785, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 25.0f, Radius = 150 } } },			// Giant Logger
			{ 00786, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 26.0f, Radius = 150 } } },			// Giant Lugger
			{ 00787, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 26.0f, Radius = 150 } } },			// Giant Reader
			{ 00788, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 29.0f, Radius = 150 } } },			// Biast
			{ 00653, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 31.0f, Radius = 150 } } },			// Snow Wolf
			{ 00790, new List<PositionInfo>() { new PositionInfo { X =  8.0f, Y = 20.0f, Radius = 150 } } },			// Hippocerf
			{ 01530, new List<PositionInfo>() { new PositionInfo { X =  5.0f, Y = 22.0f, Radius = 50, Fate = 493 } } },	// Sebek
			{ 01850, new List<PositionInfo>() { new PositionInfo { X =  4.0f, Y = 22.0f, Radius = 150 } } },			// Baritine Croc
			{ 01431, new List<PositionInfo>() { new PositionInfo { X =  8.0f, Y = 12.0f, Radius = 50, Fate = 480 } } },	// Seps
			{ 00637, new List<PositionInfo>() { new PositionInfo { X =  9.0f, Y = 12.0f, Radius = 150 } } },			// Dragonfly
			{ 01849, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y =  8.0f, Radius = 150 } } },			// Downy Aevis
			{ 01429, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 13.0f, Radius = 50, Fate = 475 } } },	// Gargamelle

			// Mor Dhona
			{ 01444, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y =  6.0f, Radius = 50, Fate = 527 } } },	// Gwyllgi
			{ 00793, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y =  5.0f, Radius = 150 } } },			// Hapalit
			{ 01442, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y =  5.0f, Radius = 50, Fate = 521 } } },	// Porus
			{ 01851, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 13.0f, Radius = 150 } } },			// Lake Cobra
			{ 01443, new List<PositionInfo>() { new PositionInfo { X = 29.8f, Y = 14.4f, Radius = 50, Fate = 525 } } },	// Dione
			{ 00649, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 16.0f, Radius = 150 } } },			// Gigas Bhikkhu
			{ 00650, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 15.0f, Radius = 150 } } },			// Daring Harrier
			{ 01441, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 14.0f, Radius = 50, Fate = 516 } } },	// Nburu
			{ 00651, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 17.0f, Radius = 150 } } },			// Raging Harrier
			{ 01811, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 16.0f, Radius = 150 } } },			// 5th Cohort Eques
			{ 01809, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 16.0f, Radius = 150 } } },			// 5th Cohort Hoplomachus
			{ 01813, new List<PositionInfo>() { new PositionInfo { X =  9.0f, Y = 14.0f, Radius = 150 } } },			// 5th Cohort Signifer
			{ 00645, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 10.0f, Radius = 150 } } },			// Mudpuppy
			{ 01610, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 10.0f, Radius = 50, Fate = 530 } } },	// Voluptuous Vivian
			{ 00027, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y =  9.0f, Radius = 150 } } },			// Nix


			// Heavensward
			// B Rank
			// Coerthas Western Highlands
			{ 04350, new List<PositionInfo>() {							// Alteci
				new PositionInfo { X = 19.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X =  7.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X =  9.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 13.0f, Radius = 50 },
            } },
			{ 04351, new List<PositionInfo>() {							// Kreutzet
				new PositionInfo { X = 25.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 31.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 13.0f, Radius = 50 },
            } },

			// The Sea of Clouds
			{ 04352, new List<PositionInfo>() {							// Gnath Cometdrone
				new PositionInfo { X = 25.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 37.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 38.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 20.0f, Y = 30.0f, Radius = 50 },
            } },
			{ 04353, new List<PositionInfo>() {							// Thextera
				new PositionInfo { X = 35.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 39.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 13.0f, Radius = 50 },
            } },

			// The Dravanian Forelands
			{ 04356, new List<PositionInfo>() {							// Scitalis
				new PositionInfo { X = 32.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 37.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 11.0f, Radius = 50 },
            } },
			{ 04357, new List<PositionInfo>() {							// The Scarecrow
				new PositionInfo { X =  7.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 38.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 27.0f, Radius = 50 },	
				new PositionInfo { X = 16.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X =  7.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X =  8.0f, Y = 15.0f, Radius = 50 },
				new PositionInfo { X =  8.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y =  9.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 14.0f, Radius = 50 },
            } },

			// The Churning Mists
			{ 04358, new List<PositionInfo>() {							// Squonk
				new PositionInfo { X = 15.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 39.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 37.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 29.0f, Radius = 50 },
            } },
			{ 04359, new List<PositionInfo>() {							// Sanu Vali of Dancing Wings
				new PositionInfo { X =  7.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X =  9.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X =  7.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y =  9.0f, Radius = 50 },
				new PositionInfo { X = 37.0f, Y = 15.0f, Radius = 50 },
            } },

			// The Dravanian Hinterlands
			{ 04354, new List<PositionInfo>() {							// Pterygotus
				new PositionInfo { X = 13.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X =  5.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X =  9.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X =  8.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 38.0f, Radius = 50 },
            } },
			{ 04355, new List<PositionInfo>() {							// False Gigantopithecus
				new PositionInfo { X = 27.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 37.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 38.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 20.0f, Radius = 50 },
            } },

			// Azys Lla
			{ 04360, new List<PositionInfo>() {							// Lycidas
				new PositionInfo { X = 14.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y =  9.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 38.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 37.0f, Y = 37.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 38.0f, Radius = 50 },
            } },
			{ 04361, new List<PositionInfo>() {							// Omni
				new PositionInfo { X = 28.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y =  6.0f, Radius = 50 },
				new PositionInfo { X = 38.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y = 38.0f, Radius = 50 },
				new PositionInfo { X =  8.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 29.0f, Radius = 50 },
            } },

			// Daily Targets
			// Coerthas Western Highlands
			{ 03481, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 12.0f, Radius = 150 } } }, // Archaeornis
			{ 03472, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 24.0f, Radius = 150 } } }, // Bergthurs
			{ 03471, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 31.0f, Radius = 150 } } }, // Deepeye
			{ 03476, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 12.0f, Radius = 150 } } }, // Frost Grenade
			{ 03480, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 17.0f, Radius = 150 } } }, // Gelato
			{ 03484, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 14.0f, Radius = 150 } } }, // Ice Commander
			{ 03475, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 16.0f, Radius = 150 } } }, // Icetrap
			{ 03487, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 09.0f, Radius = 150 } } }, // Inland Tursus
			{ 03483, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 29.0f, Radius = 150 } } }, // Lone Yeti
			{ 03485, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 21.0f, Radius = 150 } } }, // Polar Bear
			{ 03482, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 20.0f, Radius = 150 } } }, // Rheum
			{ 03473, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 24.0f, Radius = 150 } } }, // Silver Wolf
			{ 03490, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 32.0f, Radius = 150 } } }, // Slate Yeti
			{ 03478, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 12.0f, Radius = 150 } } }, // Slush Zoblyn
			{ 03470, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 32.0f, Radius = 150 } } }, // Steinbock
			{ 03474, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 20.0f, Radius = 150 } } }, // Upland Mylodon
			{ 03493, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 09.0f, Radius = 150 } } }, // Vindthurs
			{ 03479, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 17.0f, Radius = 150 } } }, // Wooly Yak

			// The Sea of Clouds
			{ 03524, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 06.0f, Radius = 150 } } }, // Anzu
			{ 03498, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 29.0f, Radius = 150 } } }, // Cloudworm
			{ 03496, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 30.0f, Radius = 150 } } }, // Conodont
			{ 03505, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 30.0f, Radius = 150 } } }, // Dhalmel
			{ 03511, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 10.0f, Radius = 150 } } }, // Endymion
			{ 03494, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 33.0f, Radius = 150 } } }, // Gaelicat
			{ 03495, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 36.0f, Radius = 150 } } }, // Gastornis
			{ 03512, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 09.0f, Radius = 150 } } }, // Groundskeeper
			{ 03506, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 30.0f, Radius = 150 } } }, // Korrigan
			{ 03501, new List<PositionInfo>() { new PositionInfo { X = 36.0f, Y = 24.0f, Radius = 150 } } }, // Lan'laii Gundu
			{ 03502, new List<PositionInfo>() { new PositionInfo { X = 36.0f, Y = 20.0f, Radius = 150 } } }, // Nat'laii Gundu
			{ 03516, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 10.0f, Radius = 150 } } }, // Nat'laii Vundu
			{ 03497, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 30.0f, Radius = 150 } } }, // Obdella
			{ 03499, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 34.0f, Radius = 150 } } }, // Paissa
			{ 03500, new List<PositionInfo>() { new PositionInfo { X = 36.0f, Y = 24.0f, Radius = 150 } } }, // Sanuwa
			{ 03514, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 14.0f, Radius = 150 } } }, // Sanuwa Vundu
			{ 03525, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 07.0f, Radius = 150 } } }, // Toco Toco
			{ 03523, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 07.0f, Radius = 150 } } }, // Tsanahale
			{ 03503, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 25.0f, Radius = 150 } } }, // Vuk'laii Gundu
			{ 03513, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 17.0f, Radius = 150 } } }, // Vundu Totem
			{ 03509, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 16.0f, Radius = 150 } } }, // Window Wamoura
			{ 03510, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 17.0f, Radius = 150 } } }, // Window Wamouracampa
			{ 03504, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 38.0f, Radius = 150 } } }, // Wisent

			// The Dravanian Forelands
			{ 03565, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 16.0f, Radius = 150 } } }, // Bandersnatch
			{ 03566, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 11.0f, Radius = 150 } } }, // Brown Bear
			{ 03570, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 22.0f, Radius = 150 } } }, // Clearwater Nanka
			{ 03569, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 25.0f, Radius = 150 } } }, // Clearwater Ninki Nanka
			{ 03572, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 32.0f, Radius = 150 } } }, // Dragonfly Watcher
			{ 03567, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 22.0f, Radius = 150 } } }, // Dravanian Aevis
			{ 03576, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 33.0f, Radius = 150 } } }, // Dravanian Wyvern
			{ 03563, new List<PositionInfo>() { new PositionInfo { X = 36.0f, Y = 24.0f, Radius = 150 } } }, // Feather Flea
			{ 03578, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 26.0f, Radius = 150 } } }, // Forelands Hippocerf
			{ 03579, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 12.0f, Radius = 150 } } }, // Gallimimus
			{ 03571, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 29.0f, Radius = 150 } } }, // Loaghtan
			{ 03592, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 35.0f, Radius = 150 } } }, // Loth Cultivator
			{ 03590, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 35.0f, Radius = 150 } } }, // Loth Firedrone
			{ 03591, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 36.0f, Radius = 150 } } }, // Loth Steeldrone
			{ 03568, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 25.0f, Radius = 150 } } }, // Melia
			{ 03577, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 31.0f, Radius = 150 } } }, // Miacid
			{ 03555, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 12.0f, Radius = 150 } } }, // Syricta
			{ 03586, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 08.0f, Radius = 150 } } }, // Thunder Dragon
			{ 03582, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 15.0f, Radius = 150 } } }, // Tyrannosaur
			{ 03581, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 14.0f, Radius = 150 } } }, // Vinegaroon
			{ 03564, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 21.0f, Radius = 150 } } }, // Wild Chocobo

			// The Churning Mists
			{ 03619, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 27.0f, Radius = 150 } } }, // Amphiptere
			{ 03620, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 26.0f, Radius = 150 } } }, // Archaeosaur
			{ 03625, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 24.0f, Radius = 150 } } }, // Bladed Vinegaroon
			{ 03630, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 10.0f, Radius = 150 } } }, // Blood Dragon
			{ 03631, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 36.0f, Radius = 150 } } }, // Cloud Aevis
			{ 03629, new List<PositionInfo>() { new PositionInfo { X = 08.0f, Y = 19.0f, Radius = 150 } } }, // Diresaur
			{ 03623, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 12.0f, Radius = 150 } } }, // Dragonet
			{ 03626, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 21.0f, Radius = 150 } } }, // Elder Syricta
			{ 03628, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 30.0f, Radius = 150 } } }, // Elder Wyvern
			{ 03668, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 20.0f, Radius = 150 } } }, // Gnarled Melia
			{ 03614, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 28.0f, Radius = 150 } } }, // Hropken
			{ 03621, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 12.0f, Radius = 150 } } }, // Limestone Golem
			{ 03618, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 28.0f, Radius = 150 } } }, // Lower Skylord
			{ 03627, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 31.0f, Radius = 150 } } }, // Mists Biast
			{ 03622, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 18.0f, Radius = 150 } } }, // Mists Drake
			{ 03617, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 25.0f, Radius = 150 } } }, // Moss Dragon
			{ 03613, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 32.0f, Radius = 150 } } }, // Sankchinni
			{ 03615, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 15.0f, Radius = 150 } } }, // Tulihand
			{ 03624, new List<PositionInfo>() { new PositionInfo { X = 38.0f, Y = 17.7f, Radius = 150 } } }, // Vouivre
			{ 03616, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 20.0f, Radius = 150 } } }, // Wadjet

			// The Dravanian Hinterlands
			{ 03612, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 37.0f, Radius = 150 } } }, // Bifericeras
			{ 03609, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 36.0f, Radius = 150 } } }, // Cockatrice
			{ 03603, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 16.0f, Radius = 150 } } }, // Crawler
			{ 03594, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 21.0f, Radius = 150 } } }, // Damselfly
			{ 03598, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 22.0f, Radius = 150 } } }, // Goblin Brandisher
			{ 03601, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 22.0f, Radius = 150 } } }, // Goblin Glider
			{ 03600, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 22.0f, Radius = 150 } } }, // Goblin Sharpshooter
			{ 03599, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 22.0f, Radius = 150 } } }, // Goblin Tinkerer
			{ 03605, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 21.0f, Radius = 150 } } }, // Great Morbol
			{ 03597, new List<PositionInfo>() { new PositionInfo { X = 37.0f, Y = 24.0f, Radius = 150 } } }, // Narbrooi
			{ 03610, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 33.0f, Radius = 150 } } }, // Okeanis
			{ 03608, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 33.0f, Radius = 150 } } }, // Opken
			{ 03604, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 27.0f, Radius = 150 } } }, // Orn Kite
			{ 03607, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 34.0f, Radius = 150 } } }, // Poroggo
			{ 03595, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 27.0f, Radius = 150 } } }, // Ratel
			{ 03611, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 32.0f, Radius = 150 } } }, // Sun Leech
			{ 03593, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 16.0f, Radius = 150 } } }, // Tarantula Hawk
			{ 03596, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 19.0f, Radius = 150 } } }, // Wildebeest

			// Azys Lla
			{ 03545, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 24.0f, Radius = 150 } } }, // 6th Legion Vanguard
			{ 03552, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 33.0f, Radius = 150 } } }, // Adamantite Claw
			{ 03540, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 06.0f, Radius = 150 } } }, // Allagan Chimera
			{ 03534, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 13.0f, Radius = 150 } } }, // Clockwork Engineer
			{ 03536, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 08.0f, Radius = 150 } } }, // Clockwork Harvestman
			{ 03535, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 13.0f, Radius = 150 } } }, // Clockwork Paladin
			{ 03542, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 09.0f, Radius = 150 } } }, // Corpse Flower
			{ 03541, new List<PositionInfo>() { new PositionInfo { X = 29.5f, Y = 12.0f, Radius = 150 } } }, // Empuse
			{ 03537, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 17.0f, Radius = 150 } } }, // Enforcement Droid
			{ 03539, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 11.0f, Radius = 150 } } }, // Lamia Cybrid
			{ 03538, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 13.0f, Radius = 150 } } }, // Lamia Thelytoke
			{ 03580, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 33.0f, Radius = 150 } } }, // Lesser Hydra
			{ 03559, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 31.0f, Radius = 150 } } }, // Meracydian Amphiptere
			{ 03557, new List<PositionInfo>() { new PositionInfo { X = 08.0f, Y = 32.0f, Radius = 150 } } }, // Meracydian Brobinyak
			{ 03560, new List<PositionInfo>() { new PositionInfo { X = 08.0f, Y = 27.0f, Radius = 150 } } }, // Meracydian Dragon
			{ 03558, new List<PositionInfo>() { new PositionInfo { X = 06.0f, Y = 35.0f, Radius = 150 } } }, // Meracydian Dragonet
			{ 03554, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 29.0f, Radius = 150 } } }, // Meracydian Falak
			{ 03556, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 35.0f, Radius = 150 } } }, // Meracydian Vouivre
			{ 03533, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 15.0f, Radius = 150 } } }, // Owlbear
			{ 03543, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 08.0f, Radius = 150 } } }, // Proto-naga
			{ 03544, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 13.0f, Radius = 150 } } }, // Reptoid
			{ 03532, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 12.0f, Radius = 150 } } }, // Snapper-rook


			// Stormblood
			// B Rank
			// The Fringes
			{ 06008, new List<PositionInfo>() {                         // Shadow-dweller Yamini
				new PositionInfo { X = 33.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 17.0f, Radius = 50 },
            } },
            { 06009, new List<PositionInfo>() {							// Ouzelum
				new PositionInfo { X = 10.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X =  8.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X =  8.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 18.0f, Radius = 50 },
            } },
			// The Peaks
			{ 06004, new List<PositionInfo>() {							// Deidar
				new PositionInfo { X = 32.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 30.0f, Radius = 50 },
            } },
            { 06005, new List<PositionInfo>() {							// Gyorai Quickstrike
				new PositionInfo { X = 28.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y =  9.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 16.0f, Radius = 50 },
            } },
			// The Ruby Sea
			{ 06003, new List<PositionInfo>() {							// Guhuo Niao
				new PositionInfo { X =  7.0f, Y =  5.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y =  6.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 24.0f, Radius = 50 },
            } },
            { 06002, new List<PositionInfo>() {							// Gauki Strongblade
				new PositionInfo { X = 32.0f, Y = 37.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X =  4.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X =  6.0f, Y = 29.0f, Radius = 50 },
            } },
			// Yanxia
			{ 06010, new List<PositionInfo>() {							// Gwas-y-neidr
				new PositionInfo { X =  5.0f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X =  7.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 36.0f, Radius = 50 },
            } },
            { 06011, new List<PositionInfo>() {							// Buccaboo
				new PositionInfo { X = 11.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X =  9.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X =  6.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 20.0f, Radius = 50 },
            } },
			// The Azim Steppe
			{ 06007, new List<PositionInfo>() {							// Aswang
				new PositionInfo { X = 28.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 13.0f, Y =  9.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 15.0f, Radius = 50 },
            } },
            { 06006, new List<PositionInfo>() {							// Kurma
				new PositionInfo { X = 24.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 14.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X =  9.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X =  9.0f, Y = 22.0f, Radius = 50 },
            } },
			// The Lochs
			{ 06013, new List<PositionInfo>() {							// Kiwa
				new PositionInfo { X = 14.0f, Y = 20.0f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 21.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 33.0f, Radius = 50 },
            } },
            { 06012, new List<PositionInfo>() {							// Manes
				new PositionInfo { X = 30.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 34.0f, Radius = 50 },
				new PositionInfo { X =  6.0f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X =  4.0f, Y = 28.0f, Radius = 50 },
				new PositionInfo { X =  7.0f, Y = 26.0f, Radius = 50 },
				new PositionInfo { X =  7.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X =  6.0f, Y =  8.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y =  7.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 11.0f, Radius = 50 },
            } },

			// Daily Targets
			// The Fringes
			{ 05685, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 27.0f, Radius = 150 } } }, // Diakka
			{ 05674, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 16.0f, Radius = 150 } } }, // Foper
			{ 05697, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 27.0f, Radius = 150 } } }, // Gazelle
			{ 05676, new List<PositionInfo>() { new PositionInfo { X = 11.6f, Y = 12.0f, Radius = 150 } } }, // Gazelle Hawk
			{ 05679, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 15.0f, Radius = 150 } } }, // Gelid Bhoot
			{ 05686, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 27.0f, Radius = 150 } } }, // Goosefish
			{ 05671, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 11.0f, Radius = 150 } } }, // Leshy
			{ 05687, new List<PositionInfo>() { new PositionInfo { X = 11.0f, Y = 17.0f, Radius = 150 } } }, // Mossling
			{ 05683, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 17.0f, Radius = 150 } } }, // Mountain Grizzly
			{ 05691, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 25.0f, Radius = 150 } } }, // Qalyana Brahmin
			{ 05689, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 25.0f, Radius = 150 } } }, // Qalyana Kshatriya
			{ 05690, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 25.0f, Radius = 150 } } }, // Qalyana Shudra
			{ 05688, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 25.0f, Radius = 150 } } }, // Sacred Marid
			{ 05675, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 12.0f, Radius = 150 } } }, // Sapria
			{ 05677, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 11.0f, Radius = 150 } } }, // Spinner
			{ 05693, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 24.0f, Radius = 150 } } }, // Teleoceras
			{ 05678, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 15.0f, Radius = 150 } } }, // Velodyna Pugil
			{ 05680, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 10.0f, Radius = 150 } } }, // Velodyna Sarcosuchus

			// The Peaks
			{ 05705, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 11.0f, Radius = 150 } } }, // Crag Claw
			{ 05701, new List<PositionInfo>() { new PositionInfo { X = 18.7f, Y = 12.9f, Radius = 150 } } }, // Bloodglider
			{ 05702, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 08.0f, Radius = 150 } } }, // Fluturini
			{ 05703, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 08.0f, Radius = 150 } } }, // Gyr Abanian Hornbill
			{ 05713, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 33.0f, Radius = 150 } } }, // Highland Eruca
			{ 05712, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 29.0f, Radius = 150 } } }, // Jhammel
			{ 05714, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 27.0f, Radius = 150 } } }, // Kongamato
			{ 05707, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 09.0f, Radius = 150 } } }, // Marble Urolith
			{ 05715, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 26.0f, Radius = 150 } } }, // Pantera
			{ 05708, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 14.0f, Radius = 150 } } }, // Scarab Beetle
			{ 05711, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 24.0f, Radius = 150 } } }, // True Griffin

			// The Ruby Sea
			{ 05737, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 35.0f, Radius = 150 } } }, // Bombfish
			{ 05736, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 05.0f, Radius = 150 } } }, // Coralshell
			{ 05740, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 30.0f, Radius = 150 } } }, // Flying Shark
			{ 05742, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 33.0f, Radius = 150 } } }, // Gasame
			{ 05734, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 10.0f, Radius = 150 } } }, // Gyuki
			{ 05751, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 25.0f, Radius = 150 } } }, // Naked Yumemi
			{ 05743, new List<PositionInfo>() { new PositionInfo { X = 07.0f, Y = 30.0f, Radius = 150 } } }, // Red Bukan
			{ 05745, new List<PositionInfo>() { new PositionInfo { X = 08.0f, Y = 28.0f, Radius = 150 } } }, // Red Honkan
			{ 05744, new List<PositionInfo>() { new PositionInfo { X = 09.5f, Y = 25.2f, Radius = 150 } } }, // Red Hyoe
			{ 05738, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 11.0f, Radius = 150 } } }, // Sea Serpent
			{ 05739, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 06.0f, Radius = 150 } } }, // Shiranui
			{ 05746, new List<PositionInfo>() { new PositionInfo { X = 07.0f, Y = 27.0f, Radius = 150 } } }, // Striped Ray
			{ 05733, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 37.0f, Radius = 150 } } }, // Tatsunoko
			{ 05735, new List<PositionInfo>() { new PositionInfo { X = 35.0f, Y = 21.0f, Radius = 150 } } }, // Unkiu
			{ 05750, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 25.0f, Radius = 150 } } }, // Yumemi

			// Yanxia
			{ 05761, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 31.0f, Radius = 150 } } }, // Bi Fang
			{ 05769, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 08.0f, Radius = 150 } } }, // Ebisu Catfish
			{ 05752, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 34.0f, Radius = 150 } } }, // Lupin Bladehand
			{ 05754, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 32.0f, Radius = 150 } } }, // Lupin Bowhand
			{ 05753, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 28.0f, Radius = 150 } } }, // Lupin Spearhand
			{ 05768, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 11.0f, Radius = 150 } } }, // Magatsu Kiyofusa
			{ 05763, new List<PositionInfo>() { new PositionInfo { X = 33.0f, Y = 17.0f, Radius = 150 } } }, // Minobi
			{ 05757, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 23.0f, Radius = 150 } } }, // Rhino Beetle
			{ 05765, new List<PositionInfo>() { new PositionInfo { X = 30.0f, Y = 34.0f, Radius = 150 } } }, // Taoquan
			{ 05755, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 32.0f, Radius = 150 } } }, // Tenaga
			{ 05764, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 30.0f, Radius = 150 } } }, // Vanara
			{ 05762, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 26.0f, Radius = 150 } } }, // Water Serpent

			// The Azim Steppe
			{ 05785, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 19.0f, Radius = 150 } } }, // Baras
			{ 05788, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 26.0f, Radius = 150 } } }, // Chaochu
			{ 05777, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 15.0f, Radius = 150 } } }, // Halgai
			{ 05778, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 11.0f, Radius = 150 } } }, // Khun Chuluu
			{ 05781, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 17.0f, Radius = 150 } } }, // Mammoth
			{ 05783, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 29.0f, Radius = 150 } } }, // Manzasiri
			{ 05775, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 13.0f, Radius = 150 } } }, // Matamata
			{ 05782, new List<PositionInfo>() { new PositionInfo { X = 09.0f, Y = 21.0f, Radius = 150 } } }, // Matanga
			{ 05779, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 10.0f, Radius = 150 } } }, // Muu Shuwuu
			{ 05780, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 18.0f, Radius = 150 } } }, // Purbol
			{ 05776, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 29.0f, Radius = 150 } } }, // Steppe Dhole
			{ 05773, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 32.0f, Radius = 150 } } }, // Steppe Dzo

			// The Lochs
			{ 05723, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 32.0f, Radius = 150 } } }, // Abaddon
			{ 05725, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 11.0f, Radius = 150 } } }, // Abalathian Minotaur
			{ 05720, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 18.0f, Radius = 150 } } }, // Chelone
			{ 05727, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 15.0f, Radius = 150 } } }, // Creeping Edila
			{ 05729, new List<PositionInfo>() { new PositionInfo { X = 05.7f, Y = 26.7f, Radius = 150 } } }, // Dark Clay Beast
			{ 05732, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 10.0f, Radius = 150 } } }, // Guard Bhoot
			{ 05716, new List<PositionInfo>() { new PositionInfo { X = 08.0f, Y = 17.0f, Radius = 150 } } }, // Kaluk
			{ 05724, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 12.0f, Radius = 150 } } }, // Loch Leech
			{ 05730, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 16.0f, Radius = 150 } } }, // Loch Nanka
			{ 05717, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 18.0f, Radius = 150 } } }, // Phoebad
			{ 05721, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 21.0f, Radius = 150 } } }, // Soblyn
			{ 05722, new List<PositionInfo>() { new PositionInfo { X = 22.0f, Y = 23.0f, Radius = 150 } } }, // Salt Dhruva
			{ 05728, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 08.0f, Radius = 150 } } }, // Specter
			{ 05726, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 29.0f, Radius = 150 } } }, // Vepar
			{ 05719, new List<PositionInfo>() { new PositionInfo { X = 20.0f, Y = 25.0f, Radius = 150 } } }, // Yabby			


			// Shadowbringers
			// B Rank
			// Lakeland
			{ 08908, new List<PositionInfo>() {							// La Velue
				new PositionInfo { X = 23.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 27.3f, Y = 15.4f, Radius = 50 },
				new PositionInfo { X = 29.4f, Y = 19.0f, Radius = 50 },
				new PositionInfo { X =  8.2f, Y = 22.7f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 12.0f, Radius = 50 }, 
				new PositionInfo { X = 14.0f, Y = 25.0f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 19.6f, Y =  9.6f, Radius = 50 },
            } },
            { 08909, new List<PositionInfo>() {							// Itzpapalotl
				new PositionInfo { X = 25.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y = 22.0f, Radius = 50 },
				new PositionInfo { X = 26.0f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 27.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 36.0f, Y = 12.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 32.0f, Radius = 50 },
				new PositionInfo { X = 35.0f, Y = 16.0f, Radius = 50 },
            } },
			// Kholusia
			{ 08913, new List<PositionInfo>() {							// Coquecigrue
				new PositionInfo { X = 17.0f, Y =  7.2f, Radius = 50 },
				new PositionInfo { X = 19.5f, Y = 10.5f, Radius = 50 },
				new PositionInfo { X = 21.3f, Y = 22.2f, Radius = 50 },
				new PositionInfo { X = 22.2f, Y = 13.7f, Radius = 50 },
				new PositionInfo { X = 22.5f, Y = 17.5f, Radius = 50 },
				new PositionInfo { X = 11.2f, Y = 18.4f, Radius = 50 },
				new PositionInfo { X = 26.7f, Y = 18.9f, Radius = 50 },
				new PositionInfo { X = 31.6f, Y = 20.2f, Radius = 50 },
				new PositionInfo { X = 25.2f, Y = 11.4f, Radius = 50 },
				new PositionInfo { X = 15.0f, Y = 15.7f, Radius = 50 },
            } },
            { 08914, new List<PositionInfo>() {							// Indomitable
				new PositionInfo { X = 15.1f, Y = 24.2f, Radius = 50 },
				new PositionInfo { X = 20.8f, Y = 31.2f, Radius = 50 },
				new PositionInfo { X = 29.7f, Y = 30.2f, Radius = 50 },
				new PositionInfo { X = 24.7f, Y = 29.7f, Radius = 50 },
				new PositionInfo { X = 26.3f, Y = 24.2f, Radius = 50 },
				new PositionInfo { X = 34.4f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X =  9.5f, Y = 25.3f, Radius = 50 },
            } },
			// Amh Araeng
			{ 08903, new List<PositionInfo>() {							// Worm of the Well
				new PositionInfo { X = 12.0f, Y = 18.0f, Radius = 50 },
				new PositionInfo { X = 19.2f, Y = 15.8f, Radius = 50 },
				new PositionInfo { X = 22.5f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 10.3f, Y = 12.2f, Radius = 50 },
				new PositionInfo { X = 16.7f, Y = 10.2f, Radius = 50 },
				new PositionInfo { X = 19.5f, Y = 25.2f, Radius = 50 },
				new PositionInfo { X = 16.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 19.5f, Y = 29.0f, Radius = 50 },
            } },
            { 08904, new List<PositionInfo>() {							// Juggler Hecatomb
				new PositionInfo { X = 28.6f, Y = 12.3f, Radius = 50 },
				new PositionInfo { X = 30.4f, Y = 34.9f, Radius = 50 },
				new PositionInfo { X = 32.8f, Y = 33.7f, Radius = 50 },
				new PositionInfo { X = 33.4f, Y = 22.1f, Radius = 50 },
				new PositionInfo { X = 23.2f, Y = 29.6f, Radius = 50 },
				new PositionInfo { X = 30.4f, Y = 13.7f, Radius = 50 },
				new PositionInfo { X = 28.3f, Y = 25.8f, Radius = 50 },
				new PositionInfo { X = 19.7f, Y = 36.5f, Radius = 50 },
            } },
			// Il Mheg
			{ 08656, new List<PositionInfo>() {							// Domovoi
				new PositionInfo { X =  7.5f, Y = 22.7f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 20.5f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y = 15.6f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 27.0f, Radius = 50 },
				new PositionInfo { X = 23.0f, Y = 33.0f, Radius = 50 },
				new PositionInfo { X = 24.9f, Y = 37.2f, Radius = 50 },
				new PositionInfo { X = 13.3f, Y = 34.2f, Radius = 50 },
				new PositionInfo { X =  8.0f, Y = 26.8f, Radius = 50 },
				new PositionInfo { X = 19.5f, Y = 35.2f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 29.0f, Radius = 50 },
				new PositionInfo { X = 10.0f, Y = 30.8f, Radius = 50 },
            } },
            { 08657, new List<PositionInfo>() {							// Vulpangue
				new PositionInfo { X = 19.8f, Y =  8.8f, Radius = 50 },
				new PositionInfo { X = 20.3f, Y =  8.2f, Radius = 50 },
				new PositionInfo { X = 25.3f, Y =  7.4f, Radius = 50 },
				new PositionInfo { X = 27.4f, Y = 18.7f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y =  5.0f, Radius = 50 },
				new PositionInfo { X = 32.0f, Y = 13.9f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y =  6.4f, Radius = 50 },
            } },
			// The Rak'tika Greatwood
			{ 08893, new List<PositionInfo>() {							// Mindmaker
				new PositionInfo { X = 15.0f, Y = 30.1f, Radius = 50 },
				new PositionInfo { X = 17.5f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X =  8.5f, Y = 35.0f, Radius = 50 },
				new PositionInfo { X = 14.5f, Y = 22.3f, Radius = 50 },
				new PositionInfo { X = 10.2f, Y = 24.2f, Radius = 50 },
				new PositionInfo { X =  9.5f, Y = 18.6f, Radius = 50 },
				new PositionInfo { X = 12.5f, Y = 35.7f, Radius = 50 },
            } },
            { 08894, new List<PositionInfo>() {							// Pachamama
				new PositionInfo { X = 26.1f, Y = 24.1f, Radius = 50 },
				new PositionInfo { X = 25.0f, Y = 30.0f, Radius = 50 },
				new PositionInfo { X = 33.0f, Y = 23.0f, Radius = 50 },
				new PositionInfo { X = 26.3f, Y = 14.9f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 10.0f, Radius = 50 },
				new PositionInfo { X = 22.0f, Y = 13.3f, Radius = 50 },
            } },
			// The Tempest
			{ 08899, new List<PositionInfo>() {							// Deacon
				new PositionInfo { X = 24.8f, Y = 24.9f, Radius = 50 },
				new PositionInfo { X = 28.7f, Y = 22.8f, Radius = 50 },
				new PositionInfo { X = 28.8f, Y =  8.1f, Radius = 50 },
				new PositionInfo { X = 29.2f, Y = 22.7f, Radius = 50 },
				new PositionInfo { X = 37.5f, Y = 16.0f, Radius = 50 },
				new PositionInfo { X = 30.9f, Y =  3.5f, Radius = 50 },
				new PositionInfo { X = 33.8f, Y = 21.4f, Radius = 50 },
				new PositionInfo { X = 36.3f, Y = 19.7f, Radius = 50 },
				new PositionInfo { X = 36.6f, Y = 11.2f, Radius = 50 },
            } },
            { 08898, new List<PositionInfo>() {							// Gilshs Aath Swiftclaw
				new PositionInfo { X =  8.5f, Y =  8.6f, Radius = 50 },
				new PositionInfo { X = 11.0f, Y =  5.0f, Radius = 50 },
				new PositionInfo { X = 13.5f, Y = 17.2f, Radius = 50 },
				new PositionInfo { X = 15.6f, Y = 19.9f, Radius = 50 },
				new PositionInfo { X = 21.0f, Y =  7.5f, Radius = 50 },
				new PositionInfo { X = 25.1f, Y = 12.7f, Radius = 50 },
				new PositionInfo { X = 18.0f, Y = 13.0f, Radius = 50 },
				new PositionInfo { X = 15.8f, Y = 11.0f, Radius = 50 },
				new PositionInfo { X = 17.0f, Y = 13.0f, Radius = 50 },
            } },

			// Daily Targets
			// Lakeland
			{ 08498, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 09.0f, Radius = 150 } } }, // Chiliad Cama
			{ 08502, new List<PositionInfo>() { new PositionInfo { X = 28.0f, Y = 23.2f, Radius = 150 } } }, // Violet Triffid
			{ 08503, new List<PositionInfo>() { new PositionInfo { X = 14.0f, Y = 16.5f, Radius = 150 } } }, // Gnole
			{ 08504, new List<PositionInfo>() { new PositionInfo { X = 24.4f, Y = 23.9f, Radius = 150 } } }, // Wetland Warg
			{ 08505, new List<PositionInfo>() { new PositionInfo { X = 33.2f, Y = 10.0f, Radius = 150 } } }, // White Gremlin
			{ 08507, new List<PositionInfo>() { new PositionInfo { X = 25.8f, Y = 23.3f, Radius = 150 } } }, // Hoptrap
			{ 08508, new List<PositionInfo>() { new PositionInfo { X = 28.5f, Y = 36.7f, Radius = 150 } } }, // Wolverine
			{ 08511, new List<PositionInfo>() { new PositionInfo { X = 11.3f, Y = 11.0f, Radius = 150 } } }, // Smilodon
			{ 08514, new List<PositionInfo>() { new PositionInfo { X = 34.2f, Y = 17.0f, Radius = 150 } } }, // Ya-te-veo
			{ 08515, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 17.6f, Radius = 150 } } }, // Proterosuchus
			{ 08786, new List<PositionInfo>() { new PositionInfo { X = 20.5f, Y = 25.3f, Radius = 150 } } }, // Lake Viper

			// Kholusia
			{ 08517, new List<PositionInfo>() { new PositionInfo { X = 31.9f, Y = 18.9f, Radius = 150 } } }, // Ironbeard
			{ 08518, new List<PositionInfo>() { new PositionInfo { X = 36.4f, Y = 28.7f, Radius = 150 } } }, // Hobgoblin
			{ 08520, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 18.0f, Radius = 150 } } }, // Defective Talos
			{ 08522, new List<PositionInfo>() { new PositionInfo { X = 34.8f, Y = 10.5f, Radius = 150 } } }, // Sulfur Byrgen
			{ 08523, new List<PositionInfo>() { new PositionInfo { X = 35.4f, Y = 29.2f, Radius = 150 } } }, // Maultasche
			{ 08524, new List<PositionInfo>() { new PositionInfo { X = 14.3f, Y = 11.4f, Radius = 150 } } }, // Huldu
			{ 08525, new List<PositionInfo>() { new PositionInfo { X = 14.3f, Y = 27.1f, Radius = 150 } } }, // Island Rail
			{ 08527, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 11.0f, Radius = 150 } } }, // Cliffkite
			{ 08528, new List<PositionInfo>() { new PositionInfo { X = 27.1f, Y = 13.8f, Radius = 150 } } }, // Cliffmole
			{ 08529, new List<PositionInfo>() { new PositionInfo { X = 08.0f, Y = 18.0f, Radius = 150 } } }, // Scree Gnome
			{ 08532, new List<PositionInfo>() { new PositionInfo { X = 17.8f, Y = 26.5f, Radius = 150 } } }, // Wood Eyes
			{ 08533, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 23.5f, Radius = 150 } } }, // Island Wolf
			{ 08534, new List<PositionInfo>() { new PositionInfo { X = 10.1f, Y = 29.6f, Radius = 150 } } }, // Kholusian Bison
			{ 08536, new List<PositionInfo>() { new PositionInfo { X = 32.5f, Y = 26.2f, Radius = 150 } } }, // Whiptail
			{ 08538, new List<PositionInfo>() { new PositionInfo { X = 22.5f, Y = 09.6f, Radius = 150 } } }, // Highland Hyssop
			{ 08539, new List<PositionInfo>() { new PositionInfo { X = 19.9f, Y = 33.0f, Radius = 150 } } }, // Tragopan
			{ 08540, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 15.0f, Radius = 150 } } }, // Saichania
			{ 08541, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 08.7f, Radius = 150 } } }, // Gulgnu
			{ 08542, new List<PositionInfo>() { new PositionInfo { X = 21.6f, Y = 32.0f, Radius = 150 } } }, // Germinant

			// Amh Araeng
			{ 08544, new List<PositionInfo>() { new PositionInfo { X = 11.4f, Y = 30.4f, Radius = 150 } } }, // Masterless Talos
			{ 08545, new List<PositionInfo>() { new PositionInfo { X = 19.1f, Y = 20.9f, Radius = 150 } } }, // Evil Weapon
			{ 08547, new List<PositionInfo>() { new PositionInfo { X = 30.4f, Y = 12.3f, Radius = 150 } } }, // Gigantender
			{ 08550, new List<PositionInfo>() { new PositionInfo { X = 29.4f, Y = 25.4f, Radius = 150 } } }, // Ancient Lizard
			{ 08556, new List<PositionInfo>() { new PositionInfo { X = 29.4f, Y = 21.7f, Radius = 150 } } }, // Sand Mole
			{ 08557, new List<PositionInfo>() { new PositionInfo { X = 12.7f, Y = 19.0f, Radius = 150 } } }, // Thistle Mole
			{ 08558, new List<PositionInfo>() { new PositionInfo { X = 30.9f, Y = 27.3f, Radius = 150 } } }, // Scissorjaws
			{ 08559, new List<PositionInfo>() { new PositionInfo { X = 21.5f, Y = 09.7f, Radius = 150 } } }, // Gnome
			{ 08561, new List<PositionInfo>() { new PositionInfo { X = 13.9f, Y = 18.2f, Radius = 150 } } }, // Debitage
			{ 08562, new List<PositionInfo>() { new PositionInfo { X = 27.1f, Y = 29.6f, Radius = 150 } } }, // Ghilman
			{ 08563, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 34.3f, Radius = 150 } } }, // Flame Zonure
			{ 08565, new List<PositionInfo>() { new PositionInfo { X = 15.2f, Y = 16.7f, Radius = 150 } } }, // Phorusrhacos
			{ 08566, new List<PositionInfo>() { new PositionInfo { X = 21.7f, Y = 09.8f, Radius = 150 } } }, // Desert Coyote
			{ 08567, new List<PositionInfo>() { new PositionInfo { X = 23.9f, Y = 31.8f, Radius = 150 } } }, // Molamander

			// Il Mheg
			{ 08155, new List<PositionInfo>() { new PositionInfo { X = 08.4f, Y = 30.0f, Radius = 150 } } }, // Flower Basket
			{ 08569, new List<PositionInfo>() { new PositionInfo { X = 18.0f, Y = 31.0f, Radius = 150 } } }, // Echevore
			{ 08574, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 14.3f, Radius = 150 } } }, // Garden Porxie
			{ 08575, new List<PositionInfo>() { new PositionInfo { X = 19.9f, Y = 16.3f, Radius = 150 } } }, // Phooka
			{ 08576, new List<PositionInfo>() { new PositionInfo { X = 11.1f, Y = 26.0f, Radius = 150 } } }, // Etainmoth
			{ 08577, new List<PositionInfo>() { new PositionInfo { X = 29.4f, Y = 12.7f, Radius = 150 } } }, // Green Glider
			{ 08578, new List<PositionInfo>() { new PositionInfo { X = 21.0f, Y = 08.8f, Radius = 150 } } }, // Moss Fungus
			{ 08581, new List<PositionInfo>() { new PositionInfo { X = 07.8f, Y = 18.7f, Radius = 150 } } }, // Hawker
			{ 08582, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 11.0f, Radius = 150 } } }, // Rainbow Lorikeet
			{ 08583, new List<PositionInfo>() { new PositionInfo { X = 29.5f, Y = 11.4f, Radius = 150 } } }, // Tot Aevis
			{ 08584, new List<PositionInfo>() { new PositionInfo { X = 30.4f, Y = 10.6f, Radius = 150 } } }, // Rabbit's Tail
			{ 08585, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 32.0f, Radius = 150 } } }, // Rosebear
			{ 08586, new List<PositionInfo>() { new PositionInfo { X = 31.6f, Y = 06.4f, Radius = 150 } } }, // Garden Crocota
			{ 08587, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 05.8f, Radius = 150 } } }, // Werewood
			{ 08590, new List<PositionInfo>() { new PositionInfo { X = 09.4f, Y = 15.0f, Radius = 150 } } }, // Killer Bee

			// The Rak'tika Greatwood
			{ 08596, new List<PositionInfo>() { new PositionInfo { X = 08.8f, Y = 35.6f, Radius = 150 } } }, // Tomatl
			{ 08597, new List<PositionInfo>() { new PositionInfo { X = 27.3f, Y = 25.6f, Radius = 150 } } }, // Forest Echo
			{ 08598, new List<PositionInfo>() { new PositionInfo { X = 25.1f, Y = 14.2f, Radius = 150 } } }, // Cracked Ronkan Doll
			{ 08599, new List<PositionInfo>() { new PositionInfo { X = 23.0f, Y = 14.0f, Radius = 150 } } }, // Cracked Ronkan Thorn
			{ 08600, new List<PositionInfo>() { new PositionInfo { X = 16.0f, Y = 32.0f, Radius = 150 } } }, // Vampire Vine
			{ 08601, new List<PositionInfo>() { new PositionInfo { X = 23.4f, Y = 07.6f, Radius = 150 } } }, // Greatwood Rail
			{ 08603, new List<PositionInfo>() { new PositionInfo { X = 29.4f, Y = 21.7f, Radius = 150 } } }, // Snapweed
			{ 08604, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 34.0f, Radius = 150 } } }, // Atrociraptor
			{ 08606, new List<PositionInfo>() { new PositionInfo { X = 27.7f, Y = 23.2f, Radius = 150 } } }, // Gizamaluk
			{ 08609, new List<PositionInfo>() { new PositionInfo { X = 16.9f, Y = 33.3f, Radius = 150 } } }, // Helm Beetle
			{ 08610, new List<PositionInfo>() { new PositionInfo { X = 34.1f, Y = 16.5f, Radius = 150 } } }, // Floor Mandrill
			{ 08611, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 19.4f, Radius = 150 } } }, // Wild Swine
			{ 08612, new List<PositionInfo>() { new PositionInfo { X = 24.9f, Y = 30.2f, Radius = 150 } } }, // Caracal
			{ 08614, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 07.2f, Radius = 150 } } }, // Woodbat
			{ 08616, new List<PositionInfo>() { new PositionInfo { X = 27.9f, Y = 21.2f, Radius = 150 } } }, // Tarichuk
			{ 08789, new List<PositionInfo>() { new PositionInfo { X = 21.1f, Y = 13.2f, Radius = 150 } } }, // Cracked Ronkan Vessel

			// The Tempest
			{ 08618, new List<PositionInfo>() { new PositionInfo { X = 28.6f, Y = 06.2f, Radius = 150 } } }, // Clinoid
			{ 08619, new List<PositionInfo>() { new PositionInfo { X = 28.2f, Y = 18.3f, Radius = 150 } } }, // Dagon
			{ 08621, new List<PositionInfo>() { new PositionInfo { X = 22.6f, Y = 31.7f, Radius = 150 } } }, // Cubus
			{ 08622, new List<PositionInfo>() { new PositionInfo { X = 25.1f, Y = 18.6f, Radius = 150 } } }, // Sea Anemone
			{ 08623, new List<PositionInfo>() { new PositionInfo { X = 32.1f, Y = 11.7f, Radius = 150 } } }, // Amphisbaena
			{ 08625, new List<PositionInfo>() { new PositionInfo { X = 32.5f, Y = 21.5f, Radius = 150 } } }, // Morgawr
			{ 08626, new List<PositionInfo>() { new PositionInfo { X = 36.6f, Y = 16.6f, Radius = 150 } } }, // Trilobite
			{ 08629, new List<PositionInfo>() { new PositionInfo { X = 27.7f, Y = 08.7f, Radius = 150 } } }, // Sea Gelatin
			{ 08630, new List<PositionInfo>() { new PositionInfo { X = 29.0f, Y = 21.0f, Radius = 150 } } }, // Tempest Swallow
			{ 08631, new List<PositionInfo>() { new PositionInfo { X = 35.8f, Y = 07.2f, Radius = 150 } } }, // Blue Swimmer

			// Endwalker
			// B Rank
			// Labyrinthos
			{ 10636, new List<PositionInfo>() {							// Ü-u-ü-u
				new PositionInfo { X =  5.9f, Y = 33.1f, Radius = 50 },
				new PositionInfo { X = 12.1f, Y = 35.4f, Radius = 50 },
				new PositionInfo { X = 10.6f, Y = 18.8f, Radius = 50 },
				new PositionInfo { X = 16.4f, Y = 17.0f, Radius = 50 },
				new PositionInfo { X = 19.7f, Y = 38.4f, Radius = 50 },
				new PositionInfo { X = 24.9f, Y = 25.4f, Radius = 50 },
            } },
            { 10635, new List<PositionInfo>() {							// Green Archon
				new PositionInfo { X = 17.2f, Y =  8.9f, Radius = 50 },
				new PositionInfo { X = 30.0f, Y =  8.1f, Radius = 50 },
				new PositionInfo { X = 34.0f, Y = 13.6f, Radius = 50 },
				new PositionInfo { X = 32.9f, Y = 25.8f, Radius = 50 },
            } },
			// Thavnair
			{ 10638, new List<PositionInfo>() {							// Iravati
				new PositionInfo { X = 18.3f, Y = 23.5f, Radius = 50 },
				new PositionInfo { X = 19.9f, Y = 31.0f, Radius = 50 },
				new PositionInfo { X = 26.4f, Y = 20.6f, Radius = 50 },
				new PositionInfo { X = 27.5f, Y = 25.1f, Radius = 50 },
				new PositionInfo { X = 32.8f, Y = 20.5f, Radius = 50 },
            } },
            { 10637, new List<PositionInfo>() {							// Vajrakumara
				new PositionInfo { X = 14.6f, Y = 11.7f, Radius = 50 },
				new PositionInfo { X = 17.4f, Y = 16.2f, Radius = 50 },
				new PositionInfo { X = 18.2f, Y = 11.7f, Radius = 50 },
				new PositionInfo { X = 29.6f, Y = 13.2f, Radius = 50 },
            } },
			// Garlemald
			{ 10640, new List<PositionInfo>() {							// Emperor's Rose
				new PositionInfo { X = 23.0f, Y = 25.7f, Radius = 50 },
				new PositionInfo { X = 27.5f, Y = 33.8f, Radius = 50 },
				new PositionInfo { X = 29.0f, Y = 20.8f, Radius = 50 },
				new PositionInfo { X = 31.8f, Y = 32.8f, Radius = 50 },
				new PositionInfo { X = 33.1f, Y = 22.2f, Radius = 50 },
            } },
            { 10639, new List<PositionInfo>() {							// Warmonger
				new PositionInfo { X =  9.5f, Y = 11.5f, Radius = 50 },
				new PositionInfo { X = 11.6f, Y = 12.9f, Radius = 50 },
				new PositionInfo { X = 12.0f, Y = 16.6f, Radius = 50 },
				new PositionInfo { X = 15.6f, Y = 19.8f, Radius = 50 },
            } },
			// Mare Lamentorum
			{ 10642, new List<PositionInfo>() {							// Genesis Rock
				new PositionInfo { X = 16.4f, Y = 28.7f, Radius = 50 },
				new PositionInfo { X = 21.3f, Y = 34.7f, Radius = 50 },
				new PositionInfo { X = 24.4f, Y = 33.4f, Radius = 50 },
				new PositionInfo { X = 30.2f, Y = 29.7f, Radius = 50 },
				new PositionInfo { X = 36.5f, Y = 26.9f, Radius = 50 },
            } },
            { 10641, new List<PositionInfo>() {							// Daphnia Magna
				new PositionInfo { X = 10.4f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 17.4f, Y = 25.1f, Radius = 50 },
				new PositionInfo { X = 18.1f, Y = 21.4f, Radius = 50 },
				new PositionInfo { X = 24.0f, Y = 24.0f, Radius = 50 },
				new PositionInfo { X = 28.0f, Y = 26.8f, Radius = 50 },
            } },
			// Elpis
			{ 10644, new List<PositionInfo>() {							// Shockmaw
				new PositionInfo { X =  7.0f, Y = 28.9f, Radius = 50 },
				new PositionInfo { X = 12.8f, Y = 32.3f, Radius = 50 },
				new PositionInfo { X = 17.9f, Y = 30.3f, Radius = 50 },
				new PositionInfo { X = 19.0f, Y = 24.6f, Radius = 50 },
				new PositionInfo { X = 29.5f, Y = 27.6f, Radius = 50 },
            } },
            { 10643, new List<PositionInfo>() {							// Yumcax
				new PositionInfo { X = 12.9f, Y =  9.4f, Radius = 50 },
				new PositionInfo { X = 21.5f, Y =  5.7f, Radius = 50 },
				new PositionInfo { X = 21.2f, Y = 13.2f, Radius = 50 },
				new PositionInfo { X = 32.5f, Y = 18.3f, Radius = 50 },
				new PositionInfo { X = 34.5f, Y = 14.0f, Radius = 50 },
				new PositionInfo { X = 34.1f, Y = 10.8f, Radius = 50 },
            } },
			// Ultima Thule
			{ 10646, new List<PositionInfo>() {							// Oskh Rhei
				new PositionInfo { X = 14.8f, Y = 36.0f, Radius = 50 },
				new PositionInfo { X = 16.3f, Y = 26.3f, Radius = 50 },
				new PositionInfo { X = 17.4f, Y = 30.3f, Radius = 50 },
				new PositionInfo { X = 21.6f, Y = 34.3f, Radius = 50 },
            } },
            { 10645, new List<PositionInfo>() {							// Level Cheater
				new PositionInfo { X =  8.1f, Y = 20.4f, Radius = 50 },
				new PositionInfo { X = 11.9f, Y = 21.9f, Radius = 50 },
				new PositionInfo { X = 13.2f, Y = 10.4f, Radius = 50 },
				new PositionInfo { X = 19.1f, Y =  9.8f, Radius = 50 },
				new PositionInfo { X = 27.7f, Y = 11.9f, Radius = 50 },
            } },

			// Daily Targets
			// Labyrinthos
			{ 10668, new List<PositionInfo>() { new PositionInfo { X = 28.8f, Y = 08.8f, Radius = 150 } } }, // Troll
			{ 10669, new List<PositionInfo>() { new PositionInfo { X = 31.0f, Y = 25.5f, Radius = 150 } } }, // Genomos
			{ 10670, new List<PositionInfo>() { new PositionInfo { X = 15.0f, Y = 06.5f, Radius = 150 } } }, // Caribou
			{ 10672, new List<PositionInfo>() { new PositionInfo { X = 32.0f, Y = 08.8f, Radius = 150 } } }, // Limascabra
			{ 10673, new List<PositionInfo>() { new PositionInfo { X = 21.5f, Y = 13.5f, Radius = 150 } } }, // Luncheon Toad
			{ 10674, new List<PositionInfo>() { new PositionInfo { X = 17.0f, Y = 12.0f, Radius = 150 } } }, // Yakow
			{ 10677, new List<PositionInfo>() { new PositionInfo { X = 34.0f, Y = 15.0f, Radius = 150 } } }, // Labyrinth Screamer
			{ 10678, new List<PositionInfo>() { new PositionInfo { X = 24.0f, Y = 10.7f, Radius = 150 } } }, // Northern Snapweed
			{ 10679, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 14.5f, Radius = 150 } } }, // Pephredo
			{ 10683, new List<PositionInfo>() { new PositionInfo { X = 37.5f, Y = 19.5f, Radius = 150 } } }, // Mythrilcap

			// Thavnair
			{ 10697, new List<PositionInfo>() { new PositionInfo { X = 19.0f, Y = 23.9f, Radius = 150 } } }, // Pisaca
			{ 10698, new List<PositionInfo>() { new PositionInfo { X = 13.8f, Y = 18.5f, Radius = 150 } } }, // Vajralangula
			{ 10699, new List<PositionInfo>() { new PositionInfo { X = 19.2f, Y = 32.6f, Radius = 150 } } }, // Kacchapa
			{ 10700, new List<PositionInfo>() { new PositionInfo { X = 18.4f, Y = 26.7f, Radius = 150 } } }, // Hamsa
			{ 10701, new List<PositionInfo>() { new PositionInfo { X = 29.1f, Y = 12.2f, Radius = 150 } } }, // Asvattha
			{ 10702, new List<PositionInfo>() { new PositionInfo { X = 27.1f, Y = 27.8f, Radius = 150 } } }, // Guhasaya
			{ 10703, new List<PositionInfo>() { new PositionInfo { X = 27.0f, Y = 17.4f, Radius = 150 } } }, // Bhujamga
			{ 10704, new List<PositionInfo>() { new PositionInfo { X = 17.6f, Y = 17.8f, Radius = 150 } } }, // Sotormurg
			{ 10705, new List<PositionInfo>() { new PositionInfo { X = 22.7f, Y = 30.4f, Radius = 150 } } }, // Gaja
			{ 10706, new List<PositionInfo>() { new PositionInfo { X = 19.1f, Y = 11.7f, Radius = 150 } } }, // Thavnairian Jhammel
			{ 10707, new List<PositionInfo>() { new PositionInfo { X = 25.9f, Y = 19.0f, Radius = 150 } } }, // Ufiti
			{ 10709, new List<PositionInfo>() { new PositionInfo { X = 09.2f, Y = 12.8f, Radius = 150 } } }, // Chamrosh
			{ 10711, new List<PositionInfo>() { new PositionInfo { X = 16.1f, Y = 09.2f, Radius = 150 } } }, // Starmite
			{ 10712, new List<PositionInfo>() { new PositionInfo { X = 14.3f, Y = 12.7f, Radius = 150 } } }, // Manjusaka
			{ 10713, new List<PositionInfo>() { new PositionInfo { X = 23.3f, Y = 19.9f, Radius = 150 } } }, // Odqan
			{ 10715, new List<PositionInfo>() { new PositionInfo { X = 13.4f, Y = 28.5f, Radius = 150 } } }, // Akyaali Crab
			{ 10716, new List<PositionInfo>() { new PositionInfo { X = 08.2f, Y = 16.2f, Radius = 150 } } }, // Valras

			// Garlemald
			{ 10648, new List<PositionInfo>() { new PositionInfo { X = 18.8f, Y = 09.8f, Radius = 150 } } }, // Automated Satellite
			{ 10649, new List<PositionInfo>() { new PositionInfo { X = 25.5f, Y = 17.5f, Radius = 150 } } }, // Automated Death Machine
			{ 10650, new List<PositionInfo>() { new PositionInfo { X = 15.5f, Y = 19.5f, Radius = 150 } } }, // Automated Cavalry
			{ 10651, new List<PositionInfo>() { new PositionInfo { X = 21.8f, Y = 17.4f, Radius = 150 } } }, // Automated Bit
			{ 10652, new List<PositionInfo>() { new PositionInfo { X = 15.7f, Y = 09.8f, Radius = 150 } } }, // Automated Roader
			{ 10653, new List<PositionInfo>() { new PositionInfo { X = 29.5f, Y = 13.7f, Radius = 150 } } }, // Automated Slasher
			{ 10654, new List<PositionInfo>() { new PositionInfo { X = 24.3f, Y = 14.9f, Radius = 150 } } }, // Automated Colossus
			{ 10655, new List<PositionInfo>() { new PositionInfo { X = 12.9f, Y = 11.7f, Radius = 150 } } }, // Automated Avenger
			{ 10656, new List<PositionInfo>() { new PositionInfo { X = 29.6f, Y = 30.3f, Radius = 150 } } }, // Almasty
			{ 10657, new List<PositionInfo>() { new PositionInfo { X = 14.6f, Y = 26.1f, Radius = 150 } } }, // Eblan Bear
			{ 10658, new List<PositionInfo>() { new PositionInfo { X = 31.3f, Y = 17.4f, Radius = 150 } } }, // Eblan Icetrap
			{ 10659, new List<PositionInfo>() { new PositionInfo { X = 19.8f, Y = 29.1f, Radius = 150 } } }, // Ovibos
			{ 10660, new List<PositionInfo>() { new PositionInfo { X = 22.3f, Y = 24.9f, Radius = 150 } } }, // Jotunn
			{ 10661, new List<PositionInfo>() { new PositionInfo { X = 28.4f, Y = 33.0f, Radius = 150 } } }, // Ceruleum Zoblyn
			{ 10662, new List<PositionInfo>() { new PositionInfo { X = 25.4f, Y = 31.5f, Radius = 150 } } }, // Ilsabardian Tursus
			{ 10663, new List<PositionInfo>() { new PositionInfo { X = 18.7f, Y = 24.8f, Radius = 150 } } }, // Canis Lupinus
			{ 10664, new List<PositionInfo>() { new PositionInfo { X = 26.1f, Y = 26.5f, Radius = 150 } } }, // Overgrown Rose

			// Mare Lamentorum
			{ 10458, new List<PositionInfo>() { new PositionInfo { X = 23.9f, Y = 20.0f, Radius = 150 } } }, // Daphnia
			{ 10459, new List<PositionInfo>() { new PositionInfo { X = 23.7f, Y = 20.3f, Radius = 150 } } }, // Osculator
			{ 10460, new List<PositionInfo>() { new PositionInfo { X = 08.6f, Y = 35.5f, Radius = 150 } } }, // Sweeper
			{ 10461, new List<PositionInfo>() { new PositionInfo { X = 27.3f, Y = 26.0f, Radius = 150 } } }, // Wanderer
			{ 10462, new List<PositionInfo>() { new PositionInfo { X = 31.1f, Y = 32.2f, Radius = 150 } } }, // Weeper
			{ 10463, new List<PositionInfo>() { new PositionInfo { X = 19.8f, Y = 22.5f, Radius = 150 } } }, // Thinker
			{ 10464, new List<PositionInfo>() { new PositionInfo { X = 26.0f, Y = 34.0f, Radius = 150 } } }, // Regolith
			{ 10465, new List<PositionInfo>() { new PositionInfo { X = 21.4f, Y = 32.2f, Radius = 150 } } }, // Trimmer
			{ 10467, new List<PositionInfo>() { new PositionInfo { X = 12.0f, Y = 36.7f, Radius = 150 } } }, // Panopt
			{ 10468, new List<PositionInfo>() { new PositionInfo { X = 11.5f, Y = 22.3f, Radius = 150 } } }, // Dynamite
			{ 10469, new List<PositionInfo>() { new PositionInfo { X = 16.7f, Y = 31.8f, Radius = 150 } } }, // Armalcolite
			{ 10470, new List<PositionInfo>() { new PositionInfo { X = 12.9f, Y = 09.6f, Radius = 150 } } }, // Caretaker
			{ 10471, new List<PositionInfo>() { new PositionInfo { X = 16.1f, Y = 24.9f, Radius = 150 } } }, // Mousse
			{ 10473, new List<PositionInfo>() { new PositionInfo { X = 31.2f, Y = 27.0f, Radius = 150 } } }, // Downfall Alarum
			{ 10474, new List<PositionInfo>() { new PositionInfo { X = 33.6f, Y = 26.2f, Radius = 150 } } }, // Downfall Droid
			{ 10475, new List<PositionInfo>() { new PositionInfo { X = 34.5f, Y = 28.0f, Radius = 150 } } }, // Downfall Hunter
			{ 10476, new List<PositionInfo>() { new PositionInfo { X = 13.0f, Y = 10.0f, Radius = 150 } } }, // Supporter
			{ 10477, new List<PositionInfo>() { new PositionInfo { X = 30.1f, Y = 11.0f, Radius = 150 } } }, // Scraper

			// Elpis
			{ 10590, new List<PositionInfo>() { new PositionInfo { X = 25.7f, Y = 33.9f, Radius = 150 } } }, // Ophion
			{ 10591, new List<PositionInfo>() { new PositionInfo { X = 16.5f, Y = 29.9f, Radius = 150 } } }, // Yggdreant
			{ 10592, new List<PositionInfo>() { new PositionInfo { X = 22.6f, Y = 20.0f, Radius = 150 } } }, // Okyupete
			{ 10594, new List<PositionInfo>() { new PositionInfo { X = 12.4f, Y = 31.8f, Radius = 150 } } }, // Gryps
			{ 10595, new List<PositionInfo>() { new PositionInfo { X = 26.6f, Y = 29.7f, Radius = 150 } } }, // Monoceros
			{ 10596, new List<PositionInfo>() { new PositionInfo { X = 10.1f, Y = 14.1f, Radius = 150 } } }, // Pegasos
			{ 10597, new List<PositionInfo>() { new PositionInfo { X = 28.7f, Y = 25.6f, Radius = 150 } } }, // Bird of Elpis
			{ 10599, new List<PositionInfo>() { new PositionInfo { X = 33.4f, Y = 14.3f, Radius = 150 } } }, // Hippe
			{ 10600, new List<PositionInfo>() { new PositionInfo { X = 14.1f, Y = 09.9f, Radius = 150 } } }, // Harpuia
			{ 10601, new List<PositionInfo>() { new PositionInfo { X = 25.0f, Y = 10.0f, Radius = 150 } } }, // Morbol Marquis
			{ 10602, new List<PositionInfo>() { new PositionInfo { X = 29.2f, Y = 09.3f, Radius = 150 } } }, // Akantha
			{ 10603, new List<PositionInfo>() { new PositionInfo { X = 24.4f, Y = 14.3f, Radius = 150 } } }, // Lykopersikon
			{ 10606, new List<PositionInfo>() { new PositionInfo { X = 21.5f, Y = 06.3f, Radius = 150 } } }, // Lotis
			{ 10607, new List<PositionInfo>() { new PositionInfo { X = 10.2f, Y = 34.6f, Radius = 150 } } }, // Phanopsyche
			{ 10608, new List<PositionInfo>() { new PositionInfo { X = 12.9f, Y = 23.4f, Radius = 150 } } }, // Melanion
			{ 10609, new List<PositionInfo>() { new PositionInfo { X = 12.9f, Y = 08.7f, Radius = 150 } } }, // Ophiotauros
			{ 10610, new List<PositionInfo>() { new PositionInfo { X = 13.3f, Y = 15.7f, Radius = 150 } } }, // Elpis Minotaur
			{ 10611, new List<PositionInfo>() { new PositionInfo { X = 30.7f, Y = 17.1f, Radius = 150 } } }, // Remora

			// Ultima Thule
			{ 10419, new List<PositionInfo>() { new PositionInfo { X = 30.1f, Y = 25.9f, Radius = 150 } } }, // Broken Omicron
			{ 10420, new List<PositionInfo>() { new PositionInfo { X = 19.3f, Y = 11.8f, Radius = 150 } } }, // Drifting Ea
			{ 10421, new List<PositionInfo>() { new PositionInfo { X = 34.8f, Y = 28.8f, Radius = 150 } } }, // Beta
			{ 10422, new List<PositionInfo>() { new PositionInfo { X = 32.9f, Y = 28.8f, Radius = 150 } } }, // Delta
			{ 10423, new List<PositionInfo>() { new PositionInfo { X = 36.5f, Y = 25.9f, Radius = 150 } } }, // Lambda
			{ 10424, new List<PositionInfo>() { new PositionInfo { X = 32.1f, Y = 26.6f, Radius = 150 } } }, // Level Tricker
			{ 10427, new List<PositionInfo>() { new PositionInfo { X = 10.0f, Y = 30.0f, Radius = 150 } } }, // Stellar Amphiptere
			{ 10430, new List<PositionInfo>() { new PositionInfo { X = 14.4f, Y = 28.2f, Radius = 150 } } }, // Stellar Brobinyak
			{ 10435, new List<PositionInfo>() { new PositionInfo { X = 16.3f, Y = 14.1f, Radius = 150 } } }, // Other One
		};

		public enum OpenType
		{
			None, // Just place marker
			ShowOpen, // Show special map with radius
			MarkerOpen // Show normal map
		}

		public static unsafe void CreateMapMarker(uint territoryType, uint mapId, uint mobHuntId, string? mobHuntName, OpenType openType = OpenType.MarkerOpen, ushort index = 1)
		{
			var map = FFXIVClientStructs.FFXIV.Client.UI.Agent.AgentMap.Instance();
			
			if (map == null)
			{
				return;
			}

			switch (openType)
			{
				case OpenType.None:
					break;
				case OpenType.ShowOpen:
					map->ResetMapMarkers();
					if (Database[mobHuntId].Count == 1 && Database[mobHuntId][0].Fate != 0)
					{
						var thing = Database[mobHuntId][0];
						var pos = MapToWorldCoordinates(Database[mobHuntId][0].Coordinate, mapId);
						map->AddGatheringTempMarker(pos.X, pos.Y, Database[mobHuntId][0].Radius, 60004, 4, mobHuntName);
						map->OpenMap(mapId, territoryType, $"FATE: {Plugin.DataManager.GetExcelSheet<Fate>()!.GetRow(thing.Fate)!.Name}", MapType.GatheringLog);
						break;
					}
					foreach (var i in Database[mobHuntId])
					{
                        var pos = MapToWorldCoordinates(i.Coordinate, mapId);
						if (!map->AddMapMarker(new Vector3 { X = pos.X, Y = 0, Z = pos.Y }, 60004))
						{
							Plugin.PluginLog.Debug("Unable to place all markers on map");
						}
					}
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
		
		private static (int X, int Y) MapToWorldCoordinates(Vector2 pos, uint mapId)
		{
			var scale = Plugin.DataManager.GetExcelSheet<Map>()?.GetRow(mapId)?.SizeFactor ?? 100;
			var num = scale / 100f;
			var x = (float)(((pos.X - 1.0) * num / 41.0 * 2048.0) - 1024.0) / num * 1000f;
			var y = (float)(((pos.Y - 1.0) * num / 41.0 * 2048.0) - 1024.0) / num * 1000f;
			x = (int)(MathF.Round(x, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f / 1000f;
			y = (int)(MathF.Round(y, 3, MidpointRounding.AwayFromZero) * 1000) * 0.001f / 1000f;
			return ((int)x, (int)y);
		}

		private static Vector2 ConvertPixelPositionToMapCoordinate(int x, int y, float scale)
		{
			var num = scale / 100f;
			return new Vector2(
				ConvertRawPositionToMapCoordinate((int)((x - 1024) * num * 1000f), scale),
				ConvertRawPositionToMapCoordinate((int)((y - 1024) * num * 1000f), scale));
		}

		private static float ConvertRawPositionToMapCoordinate(int pos, float scale)
		{
			var num1 = scale / 100f;
			var num2 = (float)(pos * (double)num1 / 1000.0f);
			return (40.96f / num1 * ((num2 + 1024.0f) / 2048.0f)) + 1.0f;
		}

		public static void TeleportToNearestAetheryte(uint territoryType, uint mapId, uint mobHuntId)
		{
			var mapRow = Plugin.DataManager.Excel.GetSheet<Map>()?.GetRow(mapId);

			if (mapRow == null)
			{
				return;
			}

			var nearestAetheryteId = Plugin.DataManager.Excel.GetSheet<MapMarker>()
				?.Where(x => x.DataType == 3 && x.RowId == mapRow.MapMarkerRange)
				.Select(
					x => new
					{
						distance = Vector2.DistanceSquared(
							Database[mobHuntId][0].Coordinate,
							ConvertPixelPositionToMapCoordinate(x.X, x.Y, mapRow.SizeFactor)),
						rowId = x.DataKey
					})
				.OrderBy(x => x.distance)
				.FirstOrDefault()?.rowId;

			var nearestAetheryte =
				territoryType == 399 // Support the unique case of aetheryte not being in the same map
					? mapRow.TerritoryType?.Value?.Aetheryte.Value
					: Plugin.DataManager.Excel.GetSheet<Aetheryte>()?.FirstOrDefault(
						x =>
							x.IsAetheryte && x.Territory.Row == territoryType && x.RowId == nearestAetheryteId);

			if (nearestAetheryte == null)
			{
				return;
			}

			Plugin.TeleportConsumer?.Teleport(nearestAetheryte.RowId);
		}
	}
}