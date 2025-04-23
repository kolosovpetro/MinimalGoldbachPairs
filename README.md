# Minimal Goldbach pairs

## Notes

- `GoldbachHelper.GeneratePjSequence(1000, 3)` generates odd primes: https://oeis.org/A065091
- `GoldbachHelper.GeneratePjSequence(1000, 5)` generates odd primes p such that p+2 is composite: https://oeis.org/A049591
- `GoldbachHelper.GeneratePjSequence(1000, 7)` generates odd primes p such that q-p >= 6, where q is the next prime after p: https://oeis.org/A124582
- `GoldbachHelper.GeneratePjSequence(1000, 7)` generates odd primes p such that p + 4, p + 6 and p + 8 are composite: https://oeis.org/A382766

Gives sequence of primes twin primes + 4
```csharp
var pjSequence = GoldbachHelper
            .GeneratePjSequence(1000, 5)
            .Except(GoldbachHelper.GeneratePjSequence(1000, 7))
            .ToList();
```

Gives https://oeis.org/A124589
```csharp
        var pjSequence =
            GoldbachHelper
                .GeneratePjSequence(2000, 3)
                .Except(GoldbachHelper.GeneratePjSequence(2000, 7))
                .ToList();
```
