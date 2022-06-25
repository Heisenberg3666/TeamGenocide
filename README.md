# TeamGenocide
[![Github All Releases](https://img.shields.io/github/downloads/Heisenberg3666/TeamGenocide/total.svg)]()

TeamGenocide is a plugin for the game SCP: SL using the Exiled framework. 
When everyone within a team has died, an auditory/visual announcement is made.

```yaml
team_genocide:
  is_enabled: true
  # These are the announcements that will be made for each team that dies.
  announcements:
    CDP:
      cassie: All class D personnel have been secured .
      subtitle: All Class D Personnel have been secured.
      broadcast: All Class D Personnel have been secured.
      hint: All Class D Personnel have been secured.
      display_for: 15
    SCP:
      cassie: All S C P subjects have been secured .
      subtitle: 
      broadcast: 
      hint: All SCP Subjects have been secured.
      display_for: 10
```
