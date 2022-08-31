import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  BusServiceProxy,
  BusDto
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-bus',
  templateUrl: './edit-bus-dialog.component.html'
})

export class EditBusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  bus: BusDto = new BusDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _busService: BusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._busService.get(this.id).subscribe((result: BusDto) => {
      this.bus = result;
    });
  }

  save(): void {
    this.saving = true;

    this._busService.update(this.bus).subscribe(
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
