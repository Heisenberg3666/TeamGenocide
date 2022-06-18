# TeamGenocide
[![Github All Releases](https://img.shields.io/github/downloads/Heisenberg3666/TeamGenocide/total.svg)]()

When all players on a Team dies, a configurable announcement is made by CASSIE, Hints and/or Broadcasts.

```yaml
team_genocide:
  is_enabled: true
  # It is recommended to come up with your own announcements for your server, these are just crappy examples.
  announcements:
  - team: CDP
    announcement_cassie: All class D personnel have been secured .
    announcement_subtitle: All Class D Personnel have been secured.
    display_for: 5
    announcement_type: Cassie, Broadcast, Hint
  - team: SCP
    announcement_cassie: All S C P subjects have been secured .
    announcement_subtitle: All SCP subjects have been secured.
    display_for: 5
    announcement_type: Cassie, Broadcast, Hint
```