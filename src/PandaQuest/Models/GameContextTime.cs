namespace PandaQuest.Models;

public readonly struct GameContextTime
{
	public readonly TimeSpan TotalTime;
	public readonly TimeSpan ElapsedTime;

	public GameContextTime(TimeSpan totalTime, TimeSpan elapsedTime)
	{
		this.TotalTime = totalTime;
		this.ElapsedTime = elapsedTime;
	}
}
