import { Component, Input, OnInit } from '@angular/core';
import { AccountReportSkill } from '../../models/account-report-skill.model';

@Component({
  selector: 'app-account-levels',
  templateUrl: './account-levels.component.html',
  styleUrls: ['./account-levels.component.scss']
})
export class AccountLevelsComponent implements OnInit {

  @Input()
  skill!: AccountReportSkill;
  
  constructor() { }

  ngOnInit(): void {
  }

}
