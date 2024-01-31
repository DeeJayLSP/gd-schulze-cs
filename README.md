Godot Schulze Demo
-

A demo showcasing the Schulze voting algorithm using C# (because I couldn't figure out how to implement in GDScript).  
  
Note that Godot here is being used more as an UI frontend.

### How to use

- Type something that represents the candidate on each field by order of preference;
- After you're done filling, press Next Vote;
- Repeat the process until all voters have voted;
- Press Finish to see the final ranking and the winner.

> The candidate list is auto-generated from the votes.

### Dependencies

This project depends on the [Perlkonig.Condorcet](https://www.nuget.org/packages/Perlkonig.Condorcet/) NuGet package, which has [its own license](https://github.com/Perlkonig/Condorcet/blob/master/LICENSE).

### Why?

Because I simply like the algorithm and wanted to see it in action.