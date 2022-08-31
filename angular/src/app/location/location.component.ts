import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  LocationServiceProxy,
  LocationDto,
  LocationDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateLocationDialogComponent } from './create-location/create-location-dialog.component';
import { EditLocationDialogComponent } from './edit-location/edit-location-dialog.component';

class PagedLocationesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  animations: [appModuleAnimation()]
})

export class LocationComponent extends PagedListingComponentBase<LocationDto> {
    locationes: LocationDto[] = [];
    keyword = '';
  
    constructor(
      injector: Injector,
      private _locationesService: LocationServiceProxy,
      private _modalService: BsModalService
    ) {
      super(injector);
    }
  
    list(
      request: PagedLocationesRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
      request.keyword = this.keyword;
  
      this._locationesService
        .getAll(request.keyword, request.skipCount, request.maxResultCount)
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: LocationDtoPagedResultDto) => {
          this.locationes = result.items;
          this.showPaging(result, pageNumber);
        });
    }
  
    delete(location: LocationDto): void {
      abp.message.confirm(
        this.l('LocationDeleteWarningMessage', location.name),
        undefined,
        (result: boolean) => {
          if (result) {
            this._locationesService
              .delete(location.id)
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
  
    createLocation(): void {
      this.showCreateOrEditLocationDialog();
    }
  
    editLocation(location: LocationDto): void {
      this.showCreateOrEditLocationDialog(location.id);
    }
  
    showCreateOrEditLocationDialog(id?: number): void {
      let createOrEditLocationDialog: BsModalRef;
      if (!id) {
        createOrEditLocationDialog = this._modalService.show(
          CreateLocationDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } else {
        createOrEditLocationDialog = this._modalService.show(
          EditLocationDialogComponent,
          {
            class: 'modal-lg',
            initialState: {
              id: id,
            },
          }
        );
      }
  
      createOrEditLocationDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }
  }
  