import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  BoardingServiceProxy,
  CreateBoardingDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  selector: 'app-create-boarding',
  templateUrl: './create-boarding-dialog.component.html'
})

export class CreateBoardingDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  boarding = new CreateBoardingDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _boardingService: BoardingServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }
 
  save(): void {
    this.saving = true;
    this._boardingService
      .create(this.boarding)
      .subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
      );
  }
}
