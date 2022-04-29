select count(revisionid) as 'Amount of Oil Changes'
from Revisions
where description like 'Oil Change';
select count(revisionid) as 'Amount of Filter Changes'
from Revisions
where description like 'Filter Change';