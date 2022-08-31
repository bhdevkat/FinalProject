import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  BusServiceProxy,
  BusDto,
  BusDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateBusDialogComponent } from './create-bus/create-bus-dialog.component';
import { EditBusDialogComponent } from './edit-bus/edit-bus-dialog.component';

class PagedBusesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-bus',
  templateUrl: './bus.component.html',
  animations: [appModuleAnimation()]
})

export class BusComponent extends PagedListingComponentBase<BusDto> {
    buses: BusDto[] = [];
    keyword = '';
  
    constructor(
      injector: Injector,
      private _busesService: BusServiceProxy,
      private _modalService: BsModalService
    ) {
      super(injector);
    }
  
    list(
      request: PagedBusesRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
      request.keyword = this.keyword;
  
      this._busesService
        .getAll(request.keyword, request.skipCount, request.maxResultCount)
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: BusDtoPagedResultDto) => {
          this.buses = result.items;
          this.showPaging(result, pageNumber);
        });
    }
  
    delete(bus: BusDto): void {
      abp.message.confirm(
        this.l('BusDeleteWarningMessage', bus.registrationNumber),
        undefined,
        (result: boolean) => {
          if (result) {
            this._busesService
              .delete(bus.id)
              .pipe(
                finalize(() => {
                  abp.notify.success(this.l('SuccessfullyDeleted'));
                  this.refresh();
                })
              )
              .subscribe(() => {});
          }
        }
      );
    }
  
    createBus(): void {
      this.showCreateOrEditBusDialog();
    }
  
    editBus(bus: BusDto): void {
      this.showCreateOrEditBusDialog(bus.id);
    }
  
    showCreateOrEditBusDialog(id?: number): void {
      let createOrEditBusDialog: BsModalRef;
      if (!id) {
        createOrEditBusDialog = this._modalService.show(
          CreateBusDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } else {
        createOrEditBusDialog = this._modalService.show(
          EditBusDialogComponent,
          {
            class: 'modal-lg',
            initialState: {
              id: id,
            },
          }
        );
      }
  
      createOrEditBusDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }
  }
  