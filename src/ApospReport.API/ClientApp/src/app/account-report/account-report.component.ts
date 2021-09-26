import { Component, OnInit } from '@angular/core';
import { BankItem } from '../shared/models/bank-item.model';
import { MatTableDataSource } from '@angular/material/table';
import { ItemImageService } from '../shared/services/item-image.service';
import * as _ from 'lodash'

export interface PeriodicElement {
  name: BankItem[];
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'app-account-report',
  templateUrl: './account-report.component.html',
  styleUrls: ['./account-report.component.css']
})
export class AccountReportComponent implements OnInit  {

  constructor(private itemImageService: ItemImageService ) {

  }
   ELEMENT_DATA: PeriodicElement[] = [
    {position: 1, name: [], weight: 1.0079, symbol: 'H'},
    {position: 2, name: [], weight: 4.0026, symbol: 'He'},
  ];

  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = new MatTableDataSource<PeriodicElement>();;

  ngOnInit(): void {
    this.ELEMENT_DATA[0].name = this.items
    this.ELEMENT_DATA[1].name = this.items

    this.setBase64ImageToBankItems();

    this.dataSource.data = this.ELEMENT_DATA;
  }

  setBase64ImageToBankItems() {
    var bankItems = _.flatten(this.ELEMENT_DATA.map(x => x.name))
    var itemImages = this.itemImageService.getItemImages();
    
    bankItems.forEach(x => {
      var foundImage = itemImages.find(i => i.id == x.id);
      x.base64 = foundImage!!.data
    });
  }
   
  itemsJson = [
    {
      "id": 1,
      "name": "eu",
      "count": 10
    },
    {
      "id": 2,
      "name": "officidda",
      "count": 27
    },
    {
      "id": 3,
      "name": "iddd",
      "count": 13
    },
    {
      "id": 4,
      "name": "nulfdsala",
      "count": 6
    },
    {
      "id": 5,
      "name": "anfdsaim",
      "count": 4
    },
    {
      "id": 6,
      "name": "eufda",
      "count": 29
    },
    {
      "id": 7,
      "name": "dofdas",
      "count": 27
    },
    {
      "id": 8,
      "name": "magadsna",
      "count": 17
    },
    {
      "id": 9,
      "name": "mafadsgna",
      "count": 26
    },
    {
      "id": 10,
      "name": "lagfbore",
      "count": 25
    },
    {
      "id": 11,
      "name": "tvxczempor",
      "count": 9
    },
    {
      "id": 12,
      "name": "esvxzt",
      "count": 30
    },
    {
      "id": 13,
      "name": "excefdsapteur",
      "count": 5
    },
    {
      "id": 14,
      "name": "evfdst",
      "count": 24
    },
    {
      "id": 15,
      "name": "Lorgfdsem",
      "count": 22
    },
    {
      "id": 16,
      "name": "adiadfapisicing",
      "count": 1
    },
    {
      "id": 17,
      "name": "labgfaoris",
      "count": 8
    },
    {
      "id": 18,
      "name": "dugfdsis",
      "count": 15
    },
    {
      "id": 19,
      "name": "adipafdsisicing",
      "count": 28
    },
    {
      "id": 20,
      "name": "migfadsnim",
      "count": 23
    },
    {
      "id": 21,
      "name": "esadsft",
      "count": 19
    },
    {
      "id": 22,
      "name": "nosgfsdatrud",
      "count": 4
    },
    {
      "id": 23,
      "name": "congfdssectetur",
      "count": 9
    },
    {
      "id": 24,
      "name": "sigfadt",
      "count": 8
    },
    {
      "id": 25,
      "name": "venfdasiam",
      "count": 19
    },
    {
      "id": 26,
      "name": "endfsaim",
      "count": 22
    },
    {
      "id": 27,
      "name": "ullafdsamco",
      "count": 4
    },
    {
      "id": 28,
      "name": "qussi",
      "count": 7
    },
    {
      "id": 29,
      "name": "fugissat",
      "count": 7
    },
    {
      "id": 30,
      "name": "aaamet",
      "count": 26
    },
    {
      "id": 31,
      "name": "reaaprehenderit",
      "count": 9
    },
    {
      "id": 32,
      "name": "marewgna",
      "count": 10
    },
    {
      "id": 33,
      "name": "essfdadse",
      "count": 10
    },
    {
      "id": 34,
      "name": "edfsadfsse",
      "count": 3
    },
    {
      "id": 35,
      "name": "esgfgdgse",
      "count": 25
    },
    {
      "id": 36,
      "name": "exhg",
      "count": 14
    },
    {
      "id": 37,
      "name": "incihgfddidunt",
      "count": 29
    },
    {
      "id": 38,
      "name": "euhgfh",
      "count": 13
    },
    {
      "id": 39,
      "name": "nisihgfdh",
      "count": 27
    },
    {
      "id": 40,
      "name": "consequathgfd",
      "count": 19
    }
  ]

  items = this.itemsJson.map(x => JSON.parse(JSON.stringify(x))  as BankItem)
}
