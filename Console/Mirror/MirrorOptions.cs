﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using DmdExt.Common;
using LibDmd.Input.ProPinball;

namespace DmdExt.Mirror
{
	class MirrorOptions : BaseOptions
	{
		[Option('s', "source", Required = true, HelpText = "The source you want to retrieve DMD data from. One of: [ pinballfx2, pinballarcade, propinball, screen ].")]
		public SourceType Source { get; set; }

		[Option('f', "fps", HelpText = "How many frames per second should be mirrored. Default: 25")]
		public double FramesPerSecond { get; set; } = 25d;

		[OptionArray("position", HelpText = "[screen] Position and size of screen grabber source. Four values: <Left> <Top> <Width> <Height>. Default: \"0 0 128 32\".")]
		public int[] Position { get; set; } = { 0, 0, 128, 32 };

		[OptionArray("resize-to", HelpText = "[screen] Resize captured screen to this size. Two values: <Width> <Height>. Default: \"128 32\".")]
		public int[] ResizeTo { get; set; } = { 128, 32 };

		[Option("grid-spacing", HelpText = "[screen] How much of the white space around the dot should be cut off (grid size is defined by --resize-to). 1 means same size as the dot, 0.5 half size, etc. 0 for disable. Default: 0.")]
		public double GridSpacing { get; set; } = 0d;

		[Option("propinball-args", HelpText = "[propinball] Arguments send from the Pro Pinball master process. Usually something like: \"ndmd w0_0_0_0_w m392\". Will be set autmatically when called through Pro Pinball.")]
		public string ProPinballArgs { get; set; } = "ndmd w0_0_0_0_w m392";

		[ParserState]
		public IParserState LastParserState { get; set; }
	}

	enum SourceType
	{
		PinballFX2,
		Screen,
		PinballArcade,
		ProPinball
	}
}
