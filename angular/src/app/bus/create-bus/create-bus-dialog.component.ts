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
  BusServiceProxy,
  CreateBusDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  selector: 'app-create-bus',
  templateUrl: './create-bus-dialog.component.html'
})

export class CreateBusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  bus = new CreateBusDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _busService: BusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }
 
  save(): void {
    this.saving = true;
    this._busService
      .create(this.bus)
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
