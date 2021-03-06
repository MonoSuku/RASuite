﻿namespace BizHawk.Client.Common
{
	public class MultitrackRecording
	{
		public void Restart()
		{
			IsActive = false;
			CurrentPlayer = 0;
			RecordAll = false;
		}

		public bool IsActive { get; set; }

		public int CurrentPlayer{ get; set; }

		public bool RecordAll { get; set; }

		/// <summary>
		/// A user friendly multitrack status
		/// </summary>
		public string CurrentState
		{
			get
			{
				if (!IsActive)
				{
					return string.Empty;
				}

				if (RecordAll)
				{
					return "Recording All";
				}

				if (CurrentPlayer == 0)
				{
					return "Recording None";
				}

				return "Recording Player " + CurrentPlayer;
			}
		}

		public void SelectAll()
		{
			CurrentPlayer = 0;
			RecordAll = true;
		}

		public void SelectNone()
		{
			RecordAll = false;
			CurrentPlayer = 0;
		}

		public void Increment()
		{
			RecordAll = false;
			CurrentPlayer++;
			if (CurrentPlayer > Global.Emulator.ControllerDefinition.PlayerCount)
			{
				CurrentPlayer = 1;
			}
		}

		public void Decrement()
		{
			RecordAll = false;
			CurrentPlayer--;
			if (CurrentPlayer < 1)
			{
				CurrentPlayer = Global.Emulator.ControllerDefinition.PlayerCount;
			}
		}
	}
}
