import { of } from "rxjs";
import { filter, map } from "rxjs/operators";

let b = of(4, 5, "lol", 6, 7);

b.pipe(
    filter(el => el > 4),
    map(el => "str " + el)
).subscribe(el => console.log(el));

console.log("OMG");