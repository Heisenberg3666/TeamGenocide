# TeamGenocide
[![Github All Releases](https://img.shields.io/github/downloads/Heisenberg3666/TeamGenocide/total.svg?style=for-the-badge)]()
[![MIT License](https://img.shields.io/badge/license-mit-red.svg?style=for-the-badge)](https://opensource.org/licenses/)

TeamGenocide is a plugin for the game SCP: SL using the Exiled framework. 
When everyone within a team has died, an auditory/visual announcement is made.

```yaml
team_genocide:
  is_enabled: true
  debug: false
  activation_delay: 5
  # These are the announcements that will be made for each team that dies.
  announcements:
    ClassD:
      - cassie: All class D personnel have been secured .
        subtitle: All Class D Personnel have been secured.
        broadcast: All Class D Personnel have been secured.
        hint: All Class D Personnel have been secured.
        display_time: 15
        lights:
          color:
            r: 0
            g: 0
            b: 0
            a: 1
          zones:
            - Surface
            - Entrance
            - HeavyContainment
            - LightContainment
          duration: 5
      - cassie:
        subtitle:
        broadcast: All Class D Personnel have been secured.
        hint: All Class D Personnel have been secured.
        display_time: 3
        lights:
          color:
            r: 1
            g: 0
            b: 1
            a: 1
          zones:
            - Surface
            - Entrance
            - HeavyContainment
            - LightContainment
          duration: 50
    SCPs:
      - cassie: All S C P subjects have been secured .
        subtitle:
        broadcast:
        hint: All SCP Subjects have been secured.
        display_time: 10
        lights:
          color:
            r: 1
            g: 0
            b: 0
            a: 1
          zones:
            - Surface
            - Entrance
            - HeavyContainment
            - LightContainment
          duration: 5
```
