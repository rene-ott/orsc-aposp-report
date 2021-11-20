import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { AccountReportSkillLevel } from '../../models/account-report-skill-level.model';

@Component({
  selector: 'app-account-levels-skill',
  templateUrl: './account-levels-skill.component.html',
  styleUrls: ['./account-levels-skill.component.scss']
})
export class AccountLevelsSkillComponent implements OnInit {

  @Input()
  skillLevel!: AccountReportSkillLevel;

  @Input()
  skillName!: string;
  
  constructor() { }

  ngOnInit(): void {
  }

}
