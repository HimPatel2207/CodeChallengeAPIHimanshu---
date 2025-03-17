import {Routes} from '@angular/router'
import {LayoutComponent} from './layout/layout/layout.component'
import { LoginComponent } from '../Auth/login/login.component'

export const routes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'dashboard'},
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: 'dashboard',
                title: 'Dashboard',
                data: {
                    icon: 'desktop_windows',
                    title: 'Dashboard'

                },
                loadChildren: () => import('./protected/dashboard/dashboard.routes')
            },
            // {
            //     path: 'drag-drop',
            //     title: 'Drag and Drop',
            //     data: {
            //         icon: 'drag_indicator',
            //         title: 'Drag and Drop'

            //     },
            //     loadChildren: () => import('./protected/drag-drop/drag-drop.routes')
            // },
            {
                path: 'table',
                title: 'Company',
                data: {
                    icon: 'table_chart',
                    title: 'Company Details'

                },
                loadChildren: () => import('./protected/table/table.routes')
            },
            // {
            //     path:'address-form',
            //     title: 'Address Form',
            //     data: {
            //         icon: 'home',
            //         title: 'Address Form'
            //     },
            //     loadChildren: () => import('./protected/address-form/address-form.routes')
            // },
            // {
            //     path: 'tree',
            //     title: 'Tree',
            //     data: {
            //         icon: 'account_tree',
            //         title: 'Tree'

            //     },
            //     loadChildren: () => import('./protected/tree/tree.routes')
            // },
            {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
        ]
    },
    {
        path: 'login',
        component: LoginComponent,
        children: [
          {
            path: 'login',
            component: LoginComponent,
          }
        ],
      }
]
