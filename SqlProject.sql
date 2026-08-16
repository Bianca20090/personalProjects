use bbi_advanced_sql;

-- a) in each decade, how many schools were there that produced MLB players
select round(yearID,-1) as decade, count(distinct(schoolID)) as NrSchools from schools
group by decade;

-- b) what are the names of the top 5 schools that produced the most players
select count(distinct(l.playerID)) as numberOfPlayers, r.name_full from schools l join school_details r
on l.schoolID=r.schoolID
group by l.schoolID
order by numberOfPlayers DESC
limit 5;

-- c) for each decade, what were the neames of the top 3 schools that produced the most players
with ds as( select round(l.yearID,-1) as decade, count(distinct(l.playerID)) as numberOfPlayers, r.name_full from schools l join school_details r
on l.schoolID=r.schoolID
group by l.schoolID, decade),

rn as (select decade, name_full, numberOfPlayers,
row_number() over(partition by decade order by numberOfPlayers desc) as row_num
 from ds)
 
 Select* from rn where row_num<=3
 order by decade DESC, numberOfPlayers;

-- d)return the top 20% of teams in terms of average annual spending
select * from salaries;
with ts as (select teamID, yearID, sum(salary) as total_spend
from salaries
group by teamID, yearID
order by teamID, yearID),

sp as (select teamID, avg(total_spend) as avg_spend, ntile(5)
 over (order by avg(total_spend) desc) as spend_pct
from ts
group by teamID)

select TeamID, round(avg_spend/1000000,1) as avg_in_millions from sp
where spend_pct=1
;

-- e) for each team, show the cumulative sum of spending over the years
with ts as (select teamID, yearID, sum(salary) as total_spend from salaries
group by teamID, yearId
order by teamID)

select *, sum(total_spend) over(partition by teamID order by yearID) as cumulative_sum
from ts;

-- f) return the first year that each team 's cumulative spending surpassed 1 billion

with ts as (select teamID, yearID, sum(salary) as total_spend from salaries
group by teamID, yearId
order by teamID),

cs as (select *, sum(total_spend) over(partition by teamID order by yearID) as cumulative_sum
from ts),

rn as (select teamID, yearID, cumulative_sum,
row_number() over(partition by teamID order by cumulative_sum) as ys

 from cs where  cumulative_sum>1000000000 )
 
 select * from rn where ys=1;
 
 -- g) for each player calculate their age at their first debut game, their last game and their career lenght (all in years)
 -- sort from longest career to shortest career
 select nameGiven, debut, finalGame, 
 cast(concat(birthYear,'-',birthMonth,'-', birthDay) as Date) as birthDate,
 timestampdiff(year, cast(concat(birthYear,'-',birthMonth,'-', birthDay) as Date), debut) as age_debut,
timestampdiff(year, cast(concat(birthYear,'-',birthMonth,'-', birthDay) as Date), finalGame) as finalGame_age,
 timestampdiff(year, debut, finalGame) as careerLenght from players
 order by careerLenght DESC;
 
 
 -- h) what team did each player play on for their starting and ending years
 select p.playerID, p.nameGiven, p.debut, p.finalGame, s.yearID, s.teamID,e.yearID, e.teamID
 from players p inner join salaries s on p.playerID=s.playerID
 and year(p.debut)=s.yearID

inner join salaries e on p.playerID=e.playerID
 and year(p.finalGame)=e.yearID ;

 
 -- i) how many players started and ended on the same team also played for over a decade?
  select p.playerID, p.nameGiven, p.debut, p.finalGame, s.yearID, s.teamID,e.yearID, e.teamID
 from players p inner join salaries s on p.playerID=s.playerID
 and year(p.debut)=s.yearID

inner join salaries e on p.playerID=e.playerID
 and year(p.finalGame)=e.yearID
 where s.teamId=e.teamID and e.yearID-s.yearID>10
