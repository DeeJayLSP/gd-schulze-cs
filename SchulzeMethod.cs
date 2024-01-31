using Condorcet;
using Godot;
using System.Linq;
using System.Collections.Generic;

public partial class SchulzeMethod : Control {
	uint candidateAmount = 4;
	uint totalVotes = 0;
	readonly List<Dictionary<string, uint>> allVotes = new();

	public void OnNextVotePressed() {
		var ballot = new Dictionary<string, uint>();
		uint index = 1;
		for (int i = 0; i < candidateAmount; i++) {
			var fieldInput = GetNode<LineEdit>("%InputField" + (i + 1).ToString()).Text;
			if (fieldInput != string.Empty) {
				ballot.Add(fieldInput, index);
				index++;
			}
		}
		allVotes.Add(ballot);
		ClearInputFields();
		GetNode<Label>("%TotalVotes").Text = "Total votes: " + ++totalVotes;
	}

	public void OnFinishPressed() {
		if (allVotes.Count < 3) {
			GetNode<Label>("%Winner").Text = "Not enough votes!";
			return;
		}
		var candidates = new HashSet<string>();
		foreach (Dictionary<string, uint> vote in allVotes) {
			foreach (string candidate in vote.Keys) candidates.Add(candidate);
		}
		var method = new Schulze<string>(candidates);
		foreach (Dictionary<string, uint> vote in allVotes) {
			method.AddBallot(vote);
		}
		var ranking = method.RankWithValues().OrderByDescending(kv => kv.Value);
		System.Text.StringBuilder sb = new();
		sb.AppendLine("Ranking:");
		foreach (KeyValuePair<string, uint> candidate in ranking) {
			sb.AppendLine(candidate.Key);
		}

		GetNode<Label>("%Winner").Text = "Winner: Candidate " + ranking.First().Key;
		GetNode<Label>("%Ranking").Text = sb.ToString();
	}

	public void ClearInputFields() {
		for (int i = 0; i < candidateAmount; i++) {
			GetNode<LineEdit>("%InputField" + (i + 1).ToString()).Text = "";
		}
	}
}
