# TeamGenocide
[![Github All Releases](https://img.shields.io/github/downloads/Heisenberg3666/TeamGenocide/total.svg)]()

When all players on a Team dies, a configurable announcement is made by CASSIE, Hints and/or Broadcasts.

```yaml
team_genocide:
  is_enabled: true
  # It is recommended to come up with your own announcements for your server, these are just crappy examples.
  announcements:
    CDP:
      announcement_cassie: All class D personnel have been secured .
      announcement_subtitle: All Class D Personnel have been secured.
      announcement_broadcast: All Class D Personnel have been secured.
      announcement_hint: All Class D Personnel have been secured.
      display_for: 5
      announcement_type: Cassie, Broadcast, Hint
    SCP:
      announcement_cassie: All S C P subjects have been secured .
      announcement_subtitle: 
      announcement_broadcast: 
      announcement_hint: All SCP Subjects have been secured.
      display_for: 5
      announcement_type: Cassie, Hint
```
